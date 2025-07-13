using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    ///  플레잉 카드 데이터
    /// @Auth samdong
    /// </summary>
    public interface ICardEffectInfo
    {
        int ID { get; }
        int GroupID { get; }
        CardEffectOperationType EffectType { get; }
        double TriggerRate { get; }
        int EffectParam { get; }
    }

    public class CardEffectInfo : ICardEffectInfo
    {
        public int ID { get; private set; }
        public int GroupID { get; private set; }
        public CardEffectOperationType EffectType { get; private set; }
        public double TriggerRate { get; private set; }
        public int EffectParam { get; private set; }

        public CardEffectInfo(int id,
            int groupID,
            CardEffectOperationType EffectType,
            double triggerRate,
            int effectParam)
        {
            this.ID = id;
            this.GroupID = groupID;
            this.EffectType = EffectType;
            this.TriggerRate = triggerRate;
            this.EffectParam = effectParam;
        }
    }
}