using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public class SelectedCardListDomain : ISelectedCardListDomain
    {
        private int _count = 0;
        private List<IBattleCard> _list = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> List => _list;

        private Subject<IReadOnlyList<IBattleCard>> _onCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _onCardListChanged;

        private Subject<IBattleCard> _onAdd = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnAdd => _onAdd;

        private Subject<IBattleCard> _onRemove = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnRemove => _onRemove;

        public bool IsAddAble => _list.Count < _count;

        public SelectedCardListDomain()
        {
            _count = 5; // TODO @Choi
        }

        public void AddCard( IBattleCard data )
        {
            _list.Add( data );
            _onAdd.OnNext( data );
            _onCardListChanged.OnNext( _list );
        }

        public void Clear()
        {
            _list.Clear();
            _onCardListChanged.OnNext( _list );
        }

        public void RemoveCard( string id )
        {
            var card = _list.Find( arg => arg.ID.Equals( id ) );
            _list.Remove( card );
            _onRemove.OnNext( card );
            _onCardListChanged.OnNext( _list );
        }

        public IBattleCard GetCard( string id )
        {
            var card = _list.First( arg => arg.ID.Equals( id ) );
            return card;
        }
    }
}
