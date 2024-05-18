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

        public IObservable<IStageInfoData> OnCurrentStageChanged => _stageInfoListDomain.OnCurrentStageChanged;

        public IStageInfoData CurrentStage => _stageInfoListDomain.CurrentStage;

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

        public IResult<IReadOnlyList<IStageInfoData>> CurrentUserStageInfoCheck( string id )
        {
            var list = _stageInfoListDomain.List;
            list.Select( arg =>
            {
                var targetId = arg.ID;
                var compare = string.Compare(targetId, id);
                arg.SetIsClear( compare <= 0 );
                return arg;
            } ).ToList();
            _stageInfoListDomain.SetList( list );
            return Result.Success( _stageInfoListDomain.List );
        }
    }
}
