
namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// ���� ���� ���� ������
    /// @Auth Samdong
    /// </summary>
    public interface IHandConditionInfo
    {
        string Name { get; }
        int AddPoint { get; }
        int MultiplePoint { get; }
    }

    public class HandConditionInfo : IHandConditionInfo
    {
        public string Name { get; private set; }
        public int AddPoint { get; private set; }
        public int MultiplePoint { get; private set; }

        public HandConditionInfo( string name, int addPoint, int multiplePoint )
        {
            this.Name = name;
            this.AddPoint = addPoint;
            this.MultiplePoint = multiplePoint;
        }
    }
}
