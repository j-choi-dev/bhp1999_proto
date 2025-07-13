using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface IHandCardListContext
    {
        IReadOnlyList<IBattleCard> List { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnListChanged { get; }
        IObservable<IBattleCard> OnAdd { get; }
        IObservable<IBattleCard> OnRemove { get; }
        void UpdateList( IReadOnlyList<IBattleCard> list );
        void Add( IBattleCard data );
        void Remove( IBattleCard data );
        void SetIsSelected( string id, bool isSelection );
        void Clear(); 
        IBattleCard GetCard( string id );
    }
}
