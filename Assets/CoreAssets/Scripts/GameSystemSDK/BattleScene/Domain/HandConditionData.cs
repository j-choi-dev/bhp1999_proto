
namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 족보 조건 데이터
    /// @Auth Samdong
    /// </summary>
    public interface IHandConditionData
    {
        int ID { get; }
        CardType CardType { get; }
        PokerNumCheckType CheckType { get; }
        int Count { get; }
    }

    public class HandConditionData : IHandConditionData
    {
        public int ID { get; private set; }
        public CardType CardType { get; private set; }
        public PokerNumCheckType CheckType { get; private set; }
        public int Count { get; private set; }

        public HandConditionData( int id, CardType cardType, PokerNumCheckType checkType, int count )
        {
            this.ID = id;
            this.CardType = cardType;
            this.CheckType = checkType;
            this.Count = count;
        }
    }
}