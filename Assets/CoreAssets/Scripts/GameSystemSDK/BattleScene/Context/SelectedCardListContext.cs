using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class SelectedCardListContext : ISelectedCardListContext
    {
        private ISelectedCardListDomain _domain;

        public IReadOnlyList<IBattleCard> List => _domain.List;

        public IObservable<IReadOnlyList<IBattleCard>> OnListChanged => _domain.OnCardListChanged;
        public IObservable<IBattleCard> OnAdd => _domain.OnAdd;
        public IObservable<IBattleCard> OnRemove => _domain.OnRemove;
        public bool IsAddAble => _domain.IsAddAble;

        public SelectedCardListContext( ISelectedCardListDomain domain )
        {
            _domain = domain;
        }

        public void Add( IBattleCard data )
            => _domain.AddCard( data );

        public void Clear()
            => _domain.Clear();

        public void Remove( string id )
        => _domain.RemoveCard( id );


        public IBattleCard GetCard( string id )
            => _domain.GetCard( id );
    }
}
