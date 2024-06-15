using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using GameSystemSDK.BattleScene.Domain;

namespace GameSystemSDK.Card.Domain
{
    public class SelectedCardListStorage : ISelectedCardListDomain
    {
        private List<IBattleCard> _list = new List<IBattleCard>();
        private Subject<IReadOnlyList<IBattleCard>> _onListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnListChanged => _onListChanged;

        private Subject<IBattleCard> _onAdd = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnAdd => _onAdd;

        private Subject<IBattleCard> _onRemoved = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnRemoved => _onRemoved;

        private Subject<Unit> _onCleared = new Subject<Unit>();
        public IObservable<Unit> OnCleared => _onCleared;

        public IReadOnlyList<IBattleCard> List => _list;

        public void Add( IBattleCard data )
        {
            _list.Add( data );
        }

        public void Clear()
        {
            _list.Clear();
        }

        public void Remove( string id )
        {
            var target = _list.Find(arg => arg.PlayingCardInfo.ID.ToString().Equals(id));
            _list.Remove( target );
        }

        public void SetCardList( IReadOnlyList<IBattleCard> list )
        {
            _list.Clear();
            _list.AddRange( list );
        }
    }
}
