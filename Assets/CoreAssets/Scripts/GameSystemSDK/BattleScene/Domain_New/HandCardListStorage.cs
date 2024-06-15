using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using UniRx;
using System.Linq;

namespace GameSystemSDK.Card.Domain
{
    public class HandCardListStorage : IHandCardListDomain
    {
        private int _totalHandDeckCount = 0; // TODO Magic Number @Choi 24.06.08

        private List<IBattleCard> _list = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> AllList => _list;
        public IReadOnlyList<IBattleCard> PlayableCardList => _list.Where( arg => arg.IsUsable && arg.IsDrawn == false ).ToList();

        private Subject<IReadOnlyList<IBattleCard>> _onListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnListChanged => _onListChanged;

        private Subject<IBattleCard> _onAdd = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnAllCardListAdd => _onAdd;

        private Subject<IBattleCard> _onRemoved = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnAllCardListRemoved => _onRemoved;

        private Subject<Unit> _onCleared = new Subject<Unit>();
        public IObservable<Unit> OnAllCardListCleared => _onCleared;

        public IReadOnlyList<IBattleCard> CurrentPlayingCardList => _list.Where( arg => arg.IsInPlayDeck && arg.IsDrawn == false ).ToList();

        private Subject<IReadOnlyList<IBattleCard>> _onPlayingCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnPlayingCardListChanged => _onPlayingCardListChanged;

        private Subject<IBattleCard> _onPlayingCardListAdd = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnPlayingCardListAdd => _onPlayingCardListAdd;
        private Subject<IBattleCard> _onPlayingCardListRemoved = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnPlayingCardListRemoved => _onPlayingCardListRemoved;
        private Subject<Unit> _onPlayingCardListCleared = new Subject<Unit>();
        public IObservable<Unit> OnPlayingCardListCleared => _onPlayingCardListCleared;

        public HandCardListStorage()
        {
            _totalHandDeckCount = 8;
        }

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
            _list.AddRange( GetShuffledList( list ) );
            _onListChanged.OnNext( _list );
        }

        public void UpdateDrawnCardStatus( IReadOnlyList<string> list )
        {
            for( int i = 0; i < list.Count; i++ )
            {
                _list.Where( arg => arg.PlayingCardInfo.ID.ToString().Equals( list[i] ) )
                    .ToList()
                    .ForEach( arg => arg.SetDrawn( true ) );
            }
            _onListChanged.OnNext( _list );
        }

        public void UpdateLockedCardStatus( IReadOnlyList<string> list )
        {
            for( int i = 0; i < list.Count; i++ )
            {
                _list.Where( arg => arg.PlayingCardInfo.ID.ToString().Equals( list[i] ) )
                    .ToList()
                    .ForEach( arg => arg.SetUsable( false ) );
            }
            _onListChanged.OnNext( _list );
        }

        public IReadOnlyList<IBattleCard> GetPlayingCardList()
        {
            //var aaa = _list.Where( x => _list.Any(y => y.Equals(x.PlayingCardInfo.ID.ToString()) == false) );
            //UnityEngine.Debug.Log( $"aaa.Count = {aaa.Count()}" );
            var target = _list.Where( x => _list.Any(y => y.Equals(x.PlayingCardInfo.ID.ToString()) == false) )
                .Where(arg => arg.IsUsable && arg.IsDrawn == false && arg.IsInPlayDeck == false )
                .ToList();
            var retVal = CurrentPlayingCardList.ToList();
            for( int i = 0; i < _totalHandDeckCount - CurrentPlayingCardList.Count; i++ )
            {
                var data = target[i];
                retVal.Add( data );
                _list.Where( arg => arg.PlayingCardInfo.ID.ToString().Equals( target[i] ) )
                    .ToList()
                    .ForEach( arg => arg.SetUsable( false ) );
                _onPlayingCardListAdd.OnNext( data );
            }
            return retVal;
        }

        private IReadOnlyList<IBattleCard> GetShuffledList( IReadOnlyList<IBattleCard> list )
        {
            var rand = new System.Random();
            var shuffled = list.OrderBy(_ => rand.Next()).ToList();
            for( int i = 0; i< shuffled.Count; i++ )
            {
                shuffled[i].SetIndex( i );
            }
            return shuffled;
        }
    }
}
