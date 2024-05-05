using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;
using UniRx;

namespace GameSystemSDK.BattleScene.Model
{
    public interface ICardListModel
    {
        UniTask Initialize();

        IReadOnlyList<IBattleCard> AllDeckList { get; }
        IReadOnlyList<IBattleCard> CurrentHandDeckList { get; }
        IReadOnlyList<IBattleCard> CurrentSelectedCardList { get; }
        IReadOnlyList<IBattleCard> CurrentUsableList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }

        IObservable<IBattleCard> OnCurrentHandCardListAdd { get; }
        IObservable<IBattleCard> OnCurrentHandCardListRemoved { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentSelectedCardListChanged { get; }
        IObservable<IBattleCard> OnCurrentSelectedCardAdd { get; }
        IObservable<IBattleCard> OnCurrentSelectedCardRemoved { get; }
        IObservable<Unit> OnSelectedCardClear { get; }

        void AddCard( IBattleCard data );
        void RemoveCard( string id );

        void UpdateCardDatas();

        void MoveToSelectedList( string id );
        void ReturnToHandList( string id );
    }
}
