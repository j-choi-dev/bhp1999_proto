using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface ICardListContext
    {
        IReadOnlyList<IBattleCard> AllList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged { get; }

        void SetCardList( IReadOnlyList<IBattleCard> list );
        IResult AddCard( IBattleCard data );
        IResult RemoveCard( string id );
        IBattleCard GetCard(string id);
    }
}
