using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class CardDeckListImportContext : ICardDeckListImportContext
    {
        ICardDeckListGenerateDomain _importDomain;

        public CardDeckListImportContext( ICardDeckListGenerateDomain importDomain )
        {
            _importDomain = importDomain;
        }

        public UniTask<IReadOnlyList<IBattleCard>> LoadShuffledList( IReadOnlyList<IPlayingCardInfo> cardList )
        {
            return _importDomain.GenerateShuffledList( cardList );
        }
    }
}
