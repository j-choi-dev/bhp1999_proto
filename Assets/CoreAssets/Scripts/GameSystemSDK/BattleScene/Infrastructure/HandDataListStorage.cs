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
                // �� �������� �� ���� ���� ���°� ����
                var id = int.Parse( CSVUtil.GetData( rawData, i, "PokerHandsID" ) );
                var pairName = CSVUtil.GetData( rawData, i, "HandsName" );
                var addPoint = int.Parse( CSVUtil.GetData( rawData, i, "AddPoint" ) );
                var multiplePoint = int.Parse( CSVUtil.GetData( rawData, i, "MultiplePoint" ) );

                // ���⼭���ʹ� ��� ���� �� ����
                string strOper = CSVUtil.GetData(rawData, i, "OperatorType");
                var oper = strOper.Equals( string.Empty ) ?
                        OperationType.None :
                        EnumUtil<OperationType>.Parse( strOper );

                var conditionList = new List<IHandConditionData>();
                for( int iter = 1; iter <= MaxConditionNum; iter++ )
                {
                    string strCondition = CSVUtil.GetData(rawData, i, "Condition" + iter.ToString());
                    if( strCondition.Equals( string.Empty ) )
                    {
                        break;
                    }

                    int iCondition = int.Parse(strCondition);
                    var condition = _handConditionDictionary[iCondition];
                    conditionList.Add( condition );
                }
                var data = new HandInfoData(id, pairName, addPoint, multiplePoint, oper, conditionList);

                _handInfoDataList.Add( data );
            }
        }

        public void InitHandConditionDataList( IReadOnlyList<Dictionary<string, string>> rawData )
        {
            for( int i = 0; i < rawData.Count; i++ )
            {
                var id = int.Parse( CSVUtil.GetData( rawData, i, "PokerHandsConditionID" ) );
                var pattern = EnumUtil<CardType>.Parse( CSVUtil.GetData( rawData, i, "PokerPattern" ) );
                var checkType = EnumUtil<PokerNumCheckType>.Parse( CSVUtil.GetData( rawData, i, "PokerNumType" ) );
                var count = int.Parse( CSVUtil.GetData( rawData, i, "Count" ) );
                var currPairCondition = new HandConditionData(id, pattern, checkType, count);
                _handConditionDictionary.Add( currPairCondition.ID, currPairCondition );
            }
        }
    }
}
