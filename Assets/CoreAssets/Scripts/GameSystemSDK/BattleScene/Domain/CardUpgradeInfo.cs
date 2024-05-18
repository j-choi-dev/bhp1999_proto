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
    }

    public class CardUpgradeInfo : ICardUpgradeInfo
    {
        public int ID { get; private set; }
        public CardUpgradeType UpgradeType { get; private set; }
        public ActivateConditionType ConditionType { get; private set; }

        public CardUpgradeInfo(int id,
            CardUpgradeType upgradeType,
            ActivateConditionType conditionType)
        {
            this.ID = id;
            this.UpgradeType = upgradeType;
            this.ConditionType = conditionType;
        }
    }
}