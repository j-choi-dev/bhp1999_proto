using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class HandScoreCalcurateContext : IHandScoreCalcurateContext
    { 
        private IHandScoreCalcuratorDomain _calcurateDomain;
        public IObservable<IDetailScoreInfo> OnDetailScoreInfo => _calcurateDomain.OnDetailScoreInfo;

        public HandScoreCalcurateContext( IHandScoreCalcuratorDomain calcurateDomain )
        {
            _calcurateDomain = calcurateDomain;
        }

        public (int id, IReadOnlyList<IBattleCard>) GetMaxPokerScore( IReadOnlyList<IHandInfoData> handDataList,
            IReadOnlyList<IBattleCard> cardList )
            => _calcurateDomain.GetMaxPokerScore( handDataList, cardList );

        public IHandConditionInfo GetPokerHandsInfoByID( IReadOnlyList<IHandInfoData> handDataList, int id )
            => _calcurateDomain.GetPokerHandsInfoByID( handDataList, id );

        public IDetailScoreInfo GetScoreData( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo condition )
            => _calcurateDomain.GetScoreData( cardList, condition );
    }
}
