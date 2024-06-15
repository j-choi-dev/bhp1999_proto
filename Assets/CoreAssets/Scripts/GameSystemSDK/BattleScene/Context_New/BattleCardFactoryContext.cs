using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Domain;
using UnityEngine;

namespace GameSystemSDK.Card.Application
{
    public class BattleCardFactoryContext : IBattleCardFactoryContext
    {
        private IBattleCardFactory _factory;

        public BattleCardFactoryContext( IBattleCardFactory factory)
        {
            _factory = factory;
        }

        public IBattleCard ConvertToBattleCard( IPlayingCardInfo playingCard, int index )
            => _factory.ConvertToBattleCard( playingCard, index );

        public IPlayingCardInfo ConvertToPlayingCard( string id, string suit, string chip, string rank, string slot1, string slot2, string slot3 )
        {
            var retVal = _factory.ConvertToBasePlayingCard( id, suit, chip, rank, slot1, slot2, slot3 );
            return retVal;
        }
    }
}
