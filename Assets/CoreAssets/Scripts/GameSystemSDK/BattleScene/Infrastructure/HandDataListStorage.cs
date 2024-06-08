using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class HandDataListStorage : IHandDataListStorageDomain
    {
        private const int MaxConditionNum = 5;

        private List<IHandInfoData> _handInfoDataList = new List<IHandInfoData>();
        public IReadOnlyList<IHandInfoData> HandInfoDataList => _handInfoDataList;

        private Dictionary<int, IHandConditionData> _handConditionDictionary = new Dictionary<int, IHandConditionData>();
        public IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary => _handConditionDictionary;


        public void InitHandDataList( IReadOnlyList<Dictionary<string, string>> rawData )
        {
            for( int i = 0; i < rawData.Count; i++ )
            {
                // 이 변수들은 안 들어가면 게임 뻗는게 맞음
                var id = int.Parse( CSVUtil.GetData( rawData, i, "pokerHandsID" ) );
                var pairName = CSVUtil.GetData( rawData, i, "handsName" );

                // 여기서부터는 비어 있을 수 있음
                string strOper = CSVUtil.GetData(rawData, i, "operatorType");
                var oper = strOper.Equals( string.Empty ) ?
                        OperationType.None :
                        EnumUtil<OperationType>.Parse( strOper );

                var conditionList = new List<IHandConditionData>();
                for( int iter = 1; iter <= MaxConditionNum; iter++ )
                {
                    string strCondition = CSVUtil.GetData(rawData, i, "condition" + iter.ToString());
                    if( strCondition.Equals( string.Empty ) )
                    {
                        break;
                    }

                    int iCondition = int.Parse(strCondition);
                    var condition = _handConditionDictionary[iCondition];
                    conditionList.Add( condition );
                }
                var data = new HandInfoData(id, pairName, oper, conditionList);

                _handInfoDataList.Add(data);
            }
        }

        public void InitHandConditionDataList( IReadOnlyList<Dictionary<string, string>> rawData )
        {
            for( int i = 0; i < rawData.Count; i++ )
            {
                var id = int.Parse( CSVUtil.GetData( rawData, i, "pokerHandsConditionID" ) );
                var pattern = EnumUtil<CardType>.Parse( CSVUtil.GetData( rawData, i, "pokerPattern" ) );
                var checkType = EnumUtil<PokerNumCheckType>.Parse( CSVUtil.GetData( rawData, i, "pokerNumType" ) );
                var count = int.Parse( CSVUtil.GetData( rawData, i, "count" ) );
                var currPairCondition = new HandConditionData(id, pattern, checkType, count);
                _handConditionDictionary.Add( currPairCondition.ID, currPairCondition );
            }
        }

        public void InitHandLevelDataList( IReadOnlyList<Dictionary<string, string>> rawData )
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                var id = int.Parse(CSVUtil.GetData(rawData, i, "pokerHandsLevelID"));
                var groupId = int.Parse(CSVUtil.GetData(rawData, i, "pokerHandsID"));
                var level = int.Parse(CSVUtil.GetData(rawData, i, "handsLevel"));
                var addPoint = int.Parse(CSVUtil.GetData(rawData, i, "addPoint"));
                var multiplePoint = int.Parse(CSVUtil.GetData(rawData, i, "multiplePoint"));

                var currHandLevel = new HandLevelData(id, groupId, level, addPoint, multiplePoint);

                foreach (var handInfo in _handInfoDataList)
                {
                    if( handInfo.ID == currHandLevel.GroupID )
                    {
                        handInfo.AddCardLevel(currHandLevel);
                    }
                }
            }
        }
    }
}
