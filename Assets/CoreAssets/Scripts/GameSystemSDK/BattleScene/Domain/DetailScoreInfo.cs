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
        int AddPoint { get; }
        public int Score { get; }
        public string GetScoreMsg ();
    }

    public class DetailScoreInfo : IDetailScoreInfo
    {
        public string Name { get; private set; }

        public IReadOnlyList<IBattleCard> HandCardList { get; private set; }

        public IReadOnlyList<int> PointList { get; private set; }

        public int MultiplePoint { get; private set; }

        public int AddPoint { get; private set; }

        public int Score { get; private set; }


        // Todo.
        // 현재는 제출한 핸드에 있는 카드로 계산
        // 추가적으로 지금 내 손에 남아 있는 카드를 순서대로 트리거 + 조커를 순서대로 트리거하는 과정을 거쳐야 한다.
        // 현재는 한방에 점수를 뽑고 있는데 장기적으로는 실제로 카드 하나씩 이펙트 터지면서 순서대로 트리거하는 방식으로
        // 변경해야 할 것으로 보인다.
        public DetailScoreInfo( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo conditionInfo )
        {
            this.Name = conditionInfo.Name;
            this.MultiplePoint = conditionInfo.MultiplePoint;
            this.AddPoint = conditionInfo.AddPoint;
            this.HandCardList = cardList;
            this.PointList = cardList.Select( arg => arg.PlayingCardInfo.Chip ).ToList();

            var realAddPoint = conditionInfo.AddPoint;
            for( var i = 0; i< cardList.Count; i++ )
            {
                realAddPoint += cardList[i].PlayingCardInfo.Chip;
            }
            this.Score = realAddPoint * conditionInfo.MultiplePoint;
        }

        public string GetScoreMsg()
        {
            var strMsg = $"판정: {Name} -> ({AddPoint} + {string.Join(" + ", PointList)}) X {MultiplePoint} = {this.Score}";
            return strMsg;
        }
    }
}
