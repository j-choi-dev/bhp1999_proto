using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class CardUpgradeListStorageDomain : ICardUpgradeListStorageDomain
    {
        private List<ICardUpgradeInfo> _cardUpgradeList = new List<ICardUpgradeInfo>();
        public IReadOnlyList<ICardUpgradeInfo> CardUpgradeList => _cardUpgradeList;

        private Dictionary<int, ICardEffectInfo> _cardEffectDictionary = new Dictionary<int, ICardEffectInfo>();
        public IReadOnlyDictionary<int, ICardEffectInfo> CardEffectDictionary => _cardEffectDictionary;


        public void InitCardUpgradeList(IReadOnlyList<Dictionary<string, string>> rawData)
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                var id = int.Parse(CSVUtil.GetData(rawData, i, "id"));
                var upgradeType = EnumUtil<CardUpgradeType>.Parse(CSVUtil.GetData(rawData, i, "CardUpgradeType"));
                var conditionType = EnumUtil<ActivateConditionType>.Parse(CSVUtil.GetData(rawData, i, "ActivateConditionType"));

                var data = new CardUpgradeInfo(id, upgradeType, conditionType);

                _cardUpgradeList.Add(data);
            }
        }

        public void InitCardEffectUpgradeList(IReadOnlyList<Dictionary<string, string>> rawData)
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                var id = int.Parse(CSVUtil.GetData(rawData, i, "id"));
                var groupId = int.Parse(CSVUtil.GetData(rawData, i, "Groupid"));
                var checkType = EnumUtil<CardEffectOperationType>.Parse(CSVUtil.GetData(rawData, i, "CardEffectOperationType"));
                var rate = double.Parse(CSVUtil.GetData(rawData, i, "OperationTriggerRate")) / 10000.0;
                var effectParam = int.Parse(CSVUtil.GetData(rawData, i, "OperationParam"));

                var currPairCondition = new CardEffectInfo(id, groupId, checkType, rate, effectParam);

                _cardEffectDictionary.Add(currPairCondition.ID, currPairCondition);
            }
        }
    }
}
