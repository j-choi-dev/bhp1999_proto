using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface ICardDeckListGenerateDomain
    {
        UniTask<IReadOnlyList<IBattleCard>> GenerateShuffledList( IReadOnlyList<IPlayingCardInfo> cardList );
    }
}
