using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface ISelectedCardListDomain
    {
        IReadOnlyList<IBattleCard> List { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IBattleCard> OnAdd { get; }
        IObservable<IBattleCard> OnRemove { get; }
        IObservable<Unit> OnClear { get; }

        bool IsAddAble { get; }

        void AddCard( IBattleCard data );
        void RemoveCard( string id );
        void Remove( IReadOnlyList<string> idList );
        void Clear();
        IBattleCard GetCard( string id );
    }
}
