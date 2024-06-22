using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class CardUpgradeListStorageDomain : ICardUpgradeListStorageDomain
    {
        private Dictionary<int, ICardUpgradeInfo> _cardUpgradeDictionary = new Dictionary<int, ICardUpgradeInfo>();
        public IReadOnlyDictionary<int, ICardUpgradeInfo> CardUpgradeDictionary => _cardUpgradeDictionary;

        public void InitCardUpgradeList(IReadOnlyList<Dictionary<string, string>> rawData)
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                var id = int.Parse(CSVUtil.GetData(rawData, i, "id"));
                var upgradeType = EnumUtil<CardUpgradeType>.Parse(CSVUtil.GetData(rawData, i, "cardUpgradeType"));
                var conditionType = EnumUtil<ActivateConditionType>.Parse(CSVUtil.GetData(rawData, i, "activateConditionType"));

                var data = new CardUpgradeInfo(id, upgradeType, conditionType);

                _cardUpgradeDictionary.Add(data.ID, data);
            }
        }

        public void InitCardEffectUpgradeList(IReadOnlyList<Dictionary<string, string>> rawData)
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                var id = int.Parse(CSVUtil.GetData(rawData, i, "id"));
                var groupId = int.Parse(CSVUtil.GetData(rawData, i, "groupid"));
                var checkType = EnumUtil<CardEffectOperationType>.Parse(CSVUtil.GetData(rawData, i, "cardEffectOperationType"));
                var rate = double.Parse(CSVUtil.GetData(rawData, i, "operationTriggerRate")) / 10000.0;
                var effectParam = int.Parse(CSVUtil.GetData(rawData, i, "operationParam"));

                var currPairCondition = new CardEffectInfo(id, groupId, checkType, rate, effectParam);

                ICardUpgradeInfo cardUpgradeInfo;
                if (_cardUpgradeDictionary.TryGetValue(currPairCondition.GroupID, out cardUpgradeInfo) == true )
                {
                    cardUpgradeInfo.AddEffect( currPairCondition );
                }
            }
        }
    }
}
