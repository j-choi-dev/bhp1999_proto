using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class CardDeckListImporter : ICardDeckListImportDomain
    {
        public async UniTask<IReadOnlyList<IBattleCard>> GenerateShuffle()
        {
            return GetShuffledCardList();
        }

        private static IReadOnlyList<IBattleCard> GetShuffledCardList()
        {
            var rand = new System.Random();
            var normalCaount = 13;
            var typeCaount = 4;
            var specialCaount = 2;

            var list = new List<IBattleCard>();
            for( int i = 0; i<typeCaount; i++ )
            {
                for( int j = 1; j<=normalCaount; j++ )
                {
                    var card = new BattleCard();
                    card.SetID( $"{i}_{j}" );
                    card.SetType( i );
                    card.SetValue( j );
                    card.SetIllustResourceID( $"card-type-{i}" );
                    card.SetIconResourceID( $"icon-type-{i}" );
                    list.Add( card );
                }
            }
            var shuffled = list.OrderBy(_ => rand.Next()).ToList();
            for( int i = 0; i< shuffled.Count; i++ )
            {
                shuffled[i].SetIndex( i );
            }
            return shuffled;
        }
    }
}
