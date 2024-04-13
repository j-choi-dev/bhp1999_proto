using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface ICardDeckListImportDomain
    {
        UniTask<IReadOnlyList<IBattleCard>> GenerateShuffle();
    }
}
