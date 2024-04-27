using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class HandCardListContext : IHandCardListContext
    {
        private IHandCardListDomain _domain;

        public IReadOnlyList<IBattleCard> List => _domain.List;

        public IObservable<IReadOnlyList<IBattleCard>> OnListChanged => _domain.OnCardListChanged;
        public IObservable<IBattleCard> OnAdd => _domain.OnAdd;
        public IObservable<IBattleCard> OnRemove => _domain.OnRemove;

        public HandCardListContext( IHandCardListDomain domain )
        {
            _domain = domain;
        }

        public void UpdateList( IReadOnlyList<IBattleCard> list )
            => _domain.UpdateList( list );

        public void Add( IBattleCard data )
            => _domain.AddCard( data );
        public void Remove( IBattleCard data )
            => _domain.RemoveCard( data );

        public void Clear()
            => _domain.Clear();

        public void SetIsSelected( string id, bool isSelection )
        => _domain.SetIsSelected( id, isSelection );


        public IBattleCard GetCard( string id )
            => _domain.GetCard( id );
    }
}
