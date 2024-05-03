using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface ICardDeckListImportContext
    {
        UniTask<IReadOnlyList<IBattleCard>> LoadShuffledList();
    }
}
