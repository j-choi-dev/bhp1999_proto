using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Card.Application
{
    public class BattleCardFactoryContext : IBattleCardFactoryContext
    {
        private IBattleCardFactory _factory;
        public IPlayingCardInfo ConvertToBattleCard( string id, string type, string value, string slot1, string slot2, string slot3 )
            => _factory.ConvertToBasePlayingCard( id, type, value, slot1, slot2, slot3 );
    }
}
