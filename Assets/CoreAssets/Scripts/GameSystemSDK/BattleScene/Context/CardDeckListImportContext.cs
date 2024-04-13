using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    public class CardDeckListImportContext : ICardDeckListImportContext
    {
        ICardDeckListImportDomain _importDomain;

        public CardDeckListImportContext( ICardDeckListImportDomain importDomain )
        {
            _importDomain = importDomain;
        }

        public UniTask<IReadOnlyList<IBattleCard>> GenerateShuffle()
        {
            return _importDomain.GenerateShuffle();
        }
    }
}
