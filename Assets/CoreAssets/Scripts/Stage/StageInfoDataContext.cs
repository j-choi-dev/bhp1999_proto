using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Server.Domain;
using GameSystemSDK.Stage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using System.Linq;

namespace GameSystemSDK.Stage.Application
{
    public class StageInfoDataContext : IStageInfoDataContext
    {
        private IDataConvertDomain _dataConvertDomain;
        private IStageInfoListDomain _stageInfoListDomain;

        public IObservable<IReadOnlyList<IStageInfoData>> OnListChanged => _stageInfoListDomain.OnListChanged;
        public IReadOnlyList<IStageInfoData> List => _stageInfoListDomain.List;

        public IObservable<IStageInfoData> OnLatestStageChanged => _stageInfoListDomain.OnLatestStageChanged;

        public IStageInfoData CurrentLatestStage => _stageInfoListDomain.CurrentLatestStage;

        public StageInfoDataContext( IDataConvertDomain dataConvertDomain,
            IStageInfoListDomain stageInfoListDomain )
        {
            _dataConvertDomain = dataConvertDomain;
            _stageInfoListDomain = stageInfoListDomain;
        }

        public void SetStageInfoByTable( string rawData )
        {
            var list = _dataConvertDomain.ConverToStageInfoDataList( rawData ).ToList();
            _stageInfoListDomain.SetList( list );
        }

        public IResult<IReadOnlyList<IStageInfoData>> CheckCurrentStageInfo( string id )
        {
            _stageInfoListDomain.UpdateClearedStage( id );
            return Result.Success( _stageInfoListDomain.List );
        }

        public IResult<IStageInfoData> GetLatestPlayableStage()
        {
            throw new NotImplementedException();
        }
    }
}
