using System.Collections.Generic;
using System.Linq;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 최종 점수 계산 정보
    /// </summary>
    public interface IDetailScoreInfo
    {
        string Name { get; }
        IReadOnlyList<IBattleCard> HandCardList { get; }
        IReadOnlyList<int> PointList { get; }
        int MultiplePoint { get; }
        public int Score { get; }
    }

    public class DetailScoreInfo : IDetailScoreInfo
    {
        public string Name { get; private set; }

        public IReadOnlyList<IBattleCard> HandCardList { get; private set; }

        public IReadOnlyList<int> PointList { get; private set; }

        public int MultiplePoint { get; private set; }

        public int Score { get; private set; }

        public DetailScoreInfo( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo conditionInfo )
        {
            this.Name = conditionInfo.Name;
            this.MultiplePoint = conditionInfo.MultiplePoint;
            this.HandCardList = cardList;
            this.PointList = cardList.Select( arg => arg.Value ).ToList();

            var realAddPoint = 0;
            for( var i = 0; i< cardList.Count; i++ )
            {
                realAddPoint += cardList[i].Value;
            }
            this.Score = realAddPoint * conditionInfo.MultiplePoint;
            var strMsg = $"판정: { conditionInfo.Name} -> ({string.Join(" + ", this.PointList)}) X {conditionInfo.MultiplePoint} = {this.Score }";
            UnityEngine.Debug.Log( $"{strMsg}" );

        }
    }
}
