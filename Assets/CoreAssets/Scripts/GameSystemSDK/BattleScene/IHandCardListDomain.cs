using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.Card.Domain
{
    public interface IHandCardListDomain
    {
        IReadOnlyList<IBattleCard> AllList { get; }
        IReadOnlyList<IBattleCard> PlayableCardList { get; }
        IReadOnlyList<IBattleCard> CurrentSetUpCardList { get; }

        IObservable<IReadOnlyList<IBattleCard>> OnListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnSetUpCardListChanged { get; }
        IObservable<IBattleCard> OnAllCardListAdd { get; }
        IObservable<IBattleCard> OnAllCardListRemoved { get; }
        IObservable<Unit> OnAllCardListCleared { get; }

        IObservable<IBattleCard> OnSetUpCardListAdd { get; }
        IObservable<IBattleCard> OnSetUpCardListRemoved { get; }

        void SetCardList( IReadOnlyList<IBattleCard> list );
        void UpdateDrawnCardStatus( IReadOnlyList<string> list );
        void UpdateLockedCardStatus( IReadOnlyList<string> list );
        IReadOnlyList<IBattleCard> GetNewSetUpCardList( IReadOnlyList<string> list );
        void Clear();
        void Add( IBattleCard data );
        void Remove( string id );
    }
}
