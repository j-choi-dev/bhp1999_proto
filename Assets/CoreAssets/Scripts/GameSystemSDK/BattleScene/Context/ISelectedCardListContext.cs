using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface ISelectedCardListContext
    {
        IReadOnlyList<IBattleCard> List { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnListChanged { get; }
        IObservable<IBattleCard> OnAdd { get; }
        IObservable<IBattleCard> OnRemove { get; }
        bool IsAddAble { get; }

        void Add( IBattleCard data );
        void Remove( string id );
        void Clear();
        IBattleCard GetCard( string id );
    }
}
