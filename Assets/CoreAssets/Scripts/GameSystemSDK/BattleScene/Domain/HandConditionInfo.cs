
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Runtime.InteropServices;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 족보 점수 조건 데이터
    /// </summary>
    /// <remarks>상호님 작성하신 스크립트</remarks>
    public interface IHandConditionInfo
    {
        string Name { get; }
        int HandLevel { get; }
        int AddPoint { get; }
        int MultiplePoint { get; }
    }

    public class HandConditionInfo : IHandConditionInfo
    {
        public string Name { get; private set; }
        public int HandLevel { get; private set; }
        public int AddPoint { get; private set; }
        public int MultiplePoint { get; private set; }

        public HandConditionInfo( string name, int handLevel, int addPoint, int multiplePoint )
        {
            Name = name;
            HandLevel = handLevel;
            AddPoint = addPoint;
            MultiplePoint = multiplePoint;
        }
    }
}
