using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain 
{
    /// <summary>
    /// Server에서 취득할 카드 아이템 기본정보
    /// </summary>
    public interface ICardBase
    {
        public string ID { get; } 
        public string Suit { get; } 
        public string Chip { get; } 
        public string Rank { get; } 
        public string EnchantSlot1 { get; } 
        public string EnchantSlot2 { get; } 
        public string EnchantSlot3 { get; } 
    }

    [System.Serializable]
    public class CardBase : ICardBase
    {
        public string ID { get; set; } = string.Empty;
        public string Suit { get; set; } = string.Empty;
        public string Chip { get; set; } = "0";
        public string Rank { get; set; } = "0";
        public string EnchantSlot1 { get; set; } = "0";
        public string EnchantSlot2 { get; set; } = "0";
        public string EnchantSlot3 { get; set; } = "0";

        public CardBase()
        {
            ID = string.Empty;
            Suit = string.Empty;
            Chip = string.Empty;
            Rank = string.Empty;
            EnchantSlot1 = "0";
            EnchantSlot2 = "0";
            EnchantSlot2 = "0";
        }

        public CardBase( string id, string suit, string chip, string rank, string slot1, string slot2, string slot3 )
        {
            ID = id;
            Suit = suit;
            Chip = chip;
            Rank = rank;
            EnchantSlot1 = slot1;
            EnchantSlot2 = slot2;
            EnchantSlot2 = slot3;
        }
    }
}
