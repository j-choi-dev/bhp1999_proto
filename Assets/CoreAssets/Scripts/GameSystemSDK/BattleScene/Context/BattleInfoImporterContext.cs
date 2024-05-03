using CommonSystem.Util;
using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class BattleInfoContext : IBattleInfoContext
    {
        private IStageInfoImporterDomain _battleInfoImporterDomain;

        private IHandDataListStorageDomain _handDataListStorageDomain;

        public IReadOnlyList<IHandInfoData> HandInfoDataList
                => _handDataListStorageDomain.HandInfoDataList;
        public IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary
                => _handDataListStorageDomain.HandConditionDictionary;

        public BattleInfoContext( IStageInfoImporterDomain battleInfoImporterDomain,
            IHandDataListStorageDomain handDataListStorageDomain )
        {
            _battleInfoImporterDomain = battleInfoImporterDomain;
            _handDataListStorageDomain = handDataListStorageDomain;
        }

        public IReadOnlyList<IStageInfoData> StageInfoList => _battleInfoImporterDomain.List;

        public IStageInfoData GetStageInfo( int index )
            => _battleInfoImporterDomain.GetBattleInfo( index );
        public IStageInfoData GetStageInfo( string id )
            => _battleInfoImporterDomain.GetBattleInfo( id );
        public UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadStageInfo(string rawData)
            => _battleInfoImporterDomain.LoadBattleInfo( rawData );

        public async UniTask InitHandDataList( string rawData )
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _handDataListStorageDomain.InitHandDataList( csvData );
        }

        public async UniTask InitHandConditionDataList( string rawData )
        {
            var csvData = CSVDataConverter.ConvertProcess(rawData);
            _handDataListStorageDomain.InitHandConditionDataList( csvData );
        }
    }
}
