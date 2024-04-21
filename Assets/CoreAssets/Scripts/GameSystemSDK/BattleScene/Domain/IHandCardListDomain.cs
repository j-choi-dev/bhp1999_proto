using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface IHandCardListDomain
    {
        IReadOnlyList<IBattleCard> List { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IBattleCard> OnAdd { get; }
        IObservable<IBattleCard> OnRemove { get; }

        void AddCard( IBattleCard data );
        void RemoveCard( string id );
        void Clear();
        void UpdateList( IReadOnlyList<IBattleCard> list );
        IBattleCard GetCard( string id );
    }
}
