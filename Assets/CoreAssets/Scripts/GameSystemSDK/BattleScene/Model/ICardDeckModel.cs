using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;

namespace GameSystemSDK.BattleScene.Model
{
    public interface ICardDeckModel
    {
        UniTask Initialize();

        IReadOnlyList<IBattleCard> AllDeckList { get; }
        IReadOnlyList<IBattleCard> CurrentHandDeckList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged { get; }
        void SetCardList( IReadOnlyList<IBattleCard> list );
        void AddCard( IBattleCard data );
        void RemoveCard( string id );
        void SetHandCardList();
    }
}
