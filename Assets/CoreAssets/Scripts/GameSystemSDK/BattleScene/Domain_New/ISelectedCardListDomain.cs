using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.Card.Domain
{
    public interface ISelectedCardListDomain
    {
        IObservable<IReadOnlyList<IBattleCard>> OnListChanged { get; }
        IObservable<IBattleCard> OnAdd { get; }
        IObservable<IBattleCard> OnRemoved { get; }
        IObservable<Unit> OnCleared { get; }
        IReadOnlyList<IBattleCard> List { get; }

        void SetCardList( IReadOnlyList<IBattleCard> list );
        void Clear();
        void Add( IBattleCard data );
        void Remove( string id );
    }
}
