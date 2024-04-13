using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface ICardListContext
    {
        IReadOnlyList<IBattleCard> AllDeckList { get; }
        IReadOnlyList<IBattleCard> CurrentHandDeckList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged { get; }
        IResult SetCardList( IReadOnlyList<IBattleCard> list );
        IResult AddCard( IBattleCard data );
        IResult RemoveCard( string id );
        IResult SetHandCardList();
    }
}
