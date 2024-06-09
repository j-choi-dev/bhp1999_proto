using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Card.Domain
{
    public interface IBattleCardFactory
    {
        IPlayingCardInfo ConvertToBasePlayingCard( string id, string type, string value, string slot1, string slot2, string slot3 );
    }
}
