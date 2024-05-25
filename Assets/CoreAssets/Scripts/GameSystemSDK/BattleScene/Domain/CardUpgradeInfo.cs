using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    ///  플레잉 카드 데이터
    /// </summary>
    /// <remarks>김상호 작성</remarks>
    public interface ICardUpgradeInfo
    {
        int ID { get; }
        CardUpgradeType UpgradeType{ get; }
        ActivateConditionType ConditionType { get; }
        IReadOnlyList<ICardEffectInfo> CardEffectList { get; }

        void AddEffect(CardEffectInfo info);
    }

    public class CardUpgradeInfo : ICardUpgradeInfo
    {
        public int ID { get; private set; }
        public CardUpgradeType UpgradeType { get; private set; }
        public ActivateConditionType ConditionType { get; private set; }

        private List<ICardEffectInfo> _cardEffectList = new List<ICardEffectInfo>();
        public IReadOnlyList<ICardEffectInfo> CardEffectList => _cardEffectList;

        public CardUpgradeInfo(int id,
            CardUpgradeType upgradeType,
            ActivateConditionType conditionType)
        {
            this.ID = id;
            this.UpgradeType = upgradeType;
            this.ConditionType = conditionType;
        }

        public void AddEffect(CardEffectInfo info)
        {
            _cardEffectList.Add(info);
        }
    }
}