using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Card List ฐüทร Domain
    /// @Auth Choi
    /// </summary>
    public interface ICardListDomain
    {
        IReadOnlyList<IBattleCard> AllDeckList { get; }
        IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged { get; }
        IResult SetCardList( IReadOnlyList<IBattleCard> list );
        IResult AddCard( IBattleCard data );
        IResult RemoveCard( string id );
        void SetIsDrawn( IReadOnlyList<string> idList );
        IBattleCard GetCard( string id );
    }
}
