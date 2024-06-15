using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Card.Application
{
    public interface IBattleCardFactoryContext
    {
        IPlayingCardInfo ConvertToPlayingCard( string id, string suit, string chip, string rank, string slot1, string slot2, string slot3 );
        IBattleCard ConvertToBattleCard( IPlayingCardInfo playingCard, int index );
    }
}
