using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain // BattleScene->Card@Choi
{
    public interface ICardBase
    {
        public string ID { get; } // Server @Choi
        public string Type { get; } // Server @Choi
        public string Value { get; } // Server @Choi
        public string EnchantSlot1 { get; } // Server @Choi
        public string EnchantSlot2 { get; } // Server @Choi
        public string EnchantSlot3 { get; } // Server @Choi
    }

    [System.Serializable]
    public class CardBase : ICardBase
    {
        public string ID { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = "0";
        public string EnchantSlot1 { get; set; } = "0";
        public string EnchantSlot2 { get; set; } = "0";
        public string EnchantSlot3 { get; set; } = "0";
    }
}
