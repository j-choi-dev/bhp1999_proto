using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Card.Domain
{
    public class BattleCardFactory : IBattleCardFactory
    {
        public IPlayingCardInfo ConvertToBasePlayingCard( string id, string type, string value, string slot1, string slot2, string slot3 )
        {
            var cardId = int.Parse(id);
            var suite = EnumUtil<CardType>.Parse(type);
            var chip = int.Parse(value);
            var val = new PlayingCardInfo(cardId, suite, chip, slot1, slot2,slot3);
            return val;
        }
    }
}
