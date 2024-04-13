using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface ICardListDomain
    {
        IReadOnlyList<IBattleCard> AllDeckList { get; }
        IReadOnlyList<IBattleCard> CurrentHandDeckList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged { get; }
        IResult SetCardList( IReadOnlyList<IBattleCard> list );
        IResult SetHandCardList();
        IResult AddCard( IBattleCard data );
        IResult RemoveCard( string id );
    }
}
