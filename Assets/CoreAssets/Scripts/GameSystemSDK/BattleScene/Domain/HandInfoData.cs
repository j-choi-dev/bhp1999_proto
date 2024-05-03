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
        int AddPoint { get; }
        int MultiplePoint { get; }
        IReadOnlyList<IHandConditionData> ConditionList { get; }
        OperationType OperationType { get; }
    }

    public class HandInfoData : IHandInfoData
    {
        public int ID { get; private set; }
        public string PairName { get; private set; }
        public int AddPoint { get; private set; }
        public int MultiplePoint { get; private set; }
        public IReadOnlyList<IHandConditionData> ConditionList { get; private set; }
        public OperationType OperationType { get; private set; }

        public HandInfoData( int id,
            string pairName,
            int addPoint,
            int multiplePoint,
            OperationType opType,
            IReadOnlyList<IHandConditionData> conditionList )
        {
            this.ID = id;
            this.PairName = pairName;
            this.AddPoint = addPoint;
            this.MultiplePoint = multiplePoint;
            this.OperationType = opType;
            this.ConditionList = conditionList;
        }
    }
}
