using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.Card.Application
{
    public interface IBattleCardListContext
    {
        /// <summary>
        /// 新) Battle Card List 기능 관련 Infrastructure와의 중계
        /// </summary>
        /// Auth : Choi 
        IObservable<IReadOnlyList<IBattleCard>> OnHandCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnSelectedCardListChanged { get; }

        IObservable<IBattleCard> OnPlayingCardAdd { get; }
        IObservable<IBattleCard> OnHandPlayingRemoved { get; }
        IObservable<Unit> OnPlayingCardCleared { get; }

        IObservable<IBattleCard> OnSelectedCardAdd { get; }
        IObservable<IBattleCard> OnSelectedCardRemoved { get; }
        IObservable<Unit> OnSelectedCardCleared { get; }

        IReadOnlyList<IBattleCard> CardList { get; }

        IReadOnlyList<IBattleCard> CurrenSelectedCard { get; }

        void SetUserCardList( IReadOnlyList<IBattleCard> list );

        void RemoveCurrentSelectedCard( IReadOnlyList<string> list );

        void RemoveCurrentSelectedCard( string id );

        void AddSelectedCard( IReadOnlyList<IBattleCard> list );
        void AddSelectedCard( IBattleCard item );
        void ClearSelectedCardList();

        void GetPlayingCardList();
    }
}
