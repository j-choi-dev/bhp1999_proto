using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    public interface ICardDeckListImportContext
    {
        UniTask<IReadOnlyList<IBattleCard>> GenerateShuffle();
    }
}
