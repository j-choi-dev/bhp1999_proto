using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    ///  족보 데이터
    /// </summary>
    /// <remarks>상호님 작성하신 스크립트</remarks>
    public interface IHandInfoData
    {
        int ID { get; }
        string PairName { get; }
        IReadOnlyList<IHandConditionData> ConditionList { get; }
        OperationType OperationType { get; }
        IReadOnlyDictionary<int, IHandLevelData> HandLevelDictionary { get; }
        void AddCardLevel(HandLevelData levelData);
    }

    public class HandInfoData : IHandInfoData
    {
        public int ID { get; private set; }
        public string PairName { get; private set; }
        public IReadOnlyList<IHandConditionData> ConditionList { get; private set; }
        public OperationType OperationType { get; private set; }

        private Dictionary<int, IHandLevelData> _handLevelDictionary = new Dictionary<int, IHandLevelData>();      
        public IReadOnlyDictionary<int, IHandLevelData> HandLevelDictionary => _handLevelDictionary;

        public HandInfoData( int id,
            string pairName,
            OperationType opType,
            IReadOnlyList<IHandConditionData> conditionList )
        {
            this.ID = id;
            this.PairName = pairName;
            this.OperationType = opType;
            this.ConditionList = conditionList;
        }

        public void AddCardLevel( HandLevelData levelData )
        {
            _handLevelDictionary.Add(levelData.HandsLevel, levelData);
        }
    }
}
