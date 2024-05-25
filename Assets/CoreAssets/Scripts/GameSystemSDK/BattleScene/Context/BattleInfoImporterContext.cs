using CommonSystem.Util;
using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Infrastructure;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class BattleInfoContext : IBattleInfoContext
    {
        private IStageInfoImporterDomain _battleInfoImporterDomain;

        private IHandDataListStorageDomain _handDataListStorageDomain;

        private IPlayingCardListStorageDomain _playingCardListStorageDomain;

        private ICardUpgradeListStorageDomain _cardUpgradeListStorageDomain;

        public IReadOnlyList<IHandInfoData> HandInfoDataList
                => _handDataListStorageDomain.HandInfoDataList;
        public IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary
                => _handDataListStorageDomain.HandConditionDictionary;

        public IReadOnlyList<IPlayingCardInfo> PlayingCardInfoList
                => _playingCardListStorageDomain.PlayingCardDeckList;

        public IReadOnlyDictionary<int, ICardUpgradeInfo> CardUpgradeDictionary
                => _cardUpgradeListStorageDomain.CardUpgradeDictionary;

        public BattleInfoContext( IStageInfoImporterDomain battleInfoImporterDomain,
            IHandDataListStorageDomain handDataListStorageDomain,
            IPlayingCardListStorageDomain playingCardListStorageDomain,
            ICardUpgradeListStorageDomain cardUpgradeListStorageDomain)
        {
            _battleInfoImporterDomain = battleInfoImporterDomain;
            _handDataListStorageDomain = handDataListStorageDomain;
            _playingCardListStorageDomain = playingCardListStorageDomain;
            _cardUpgradeListStorageDomain = cardUpgradeListStorageDomain;
        }

        public IReadOnlyList<IStageInfoData> StageInfoList => _battleInfoImporterDomain.List;

        public IStageInfoData GetStageInfo( int index )
            => _battleInfoImporterDomain.GetBattleInfo( index );
        public IStageInfoData GetStageInfo( string id )
            => _battleInfoImporterDomain.GetBattleInfo( id );
        public UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadStageInfo(string rawData)
            => _battleInfoImporterDomain.LoadBattleInfo( rawData );

        public void InitHandDataList( string rawData )
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _handDataListStorageDomain.InitHandDataList( csvData );
        }

        public void InitHandConditionDataList( string rawData )
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _handDataListStorageDomain.InitHandConditionDataList( csvData );
        }

        public void InitHandLevelDataList(string rawData)
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _handDataListStorageDomain.InitHandLevelDataList(csvData);
        }

        public void InitPlayingCardListStorageDomain( string rawData )
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _playingCardListStorageDomain.InitPlayingCardList(csvData);
        }

        public void InitCardUpgradeStorageDomain(string rawData)
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _cardUpgradeListStorageDomain.InitCardUpgradeList(csvData);
        }

        public void InitCardEffectStorageDomain(string rawData)
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _cardUpgradeListStorageDomain.InitCardEffectUpgradeList(csvData);
        }

        public IReadOnlyList<IPlayingCardInfo> GetPlayingCardDeck(int DeckGroup)
        {
            List<IPlayingCardInfo> retVal = new List<IPlayingCardInfo>();
            foreach ( var playingcard in PlayingCardInfoList )
            {
                if( playingcard.DeckGroup == DeckGroup )
                {
                    retVal.Add( playingcard );
                }
            }

            return retVal;
        }
    }
}
