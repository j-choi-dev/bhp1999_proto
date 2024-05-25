using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    ///  족보 데이터
    /// </summary>
    /// <remarks>상호님 작성하신 스크립트</remarks>
    public interface IHandLevelData
    {
        int ID { get; }
        int GroupID { get; }
        int HandsLevel { get; }
        int AddPoint { get; }
        int MultiplePoint { get; }
    }

    public class HandLevelData : IHandLevelData
    {
        public int ID { get; private set; }
        public int GroupID { get; private set; }
        public int HandsLevel { get; private set; }
        public int AddPoint { get; private set; }
        public int MultiplePoint { get; private set; }

        public HandLevelData( int id,
            int groupID,
            int handLevel,
            int addPoint,
            int multiplePoint)
        {
            this.ID = id;
            this.GroupID = groupID;
            this.HandsLevel = handLevel;
            this.AddPoint = addPoint;
            this.MultiplePoint = multiplePoint;
        }
    }
}
