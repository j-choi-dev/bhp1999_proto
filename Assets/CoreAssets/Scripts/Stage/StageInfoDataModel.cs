using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Resource.Application;
using GameSystemSDK.Server.Application;
using GameSystemSDK.Stage.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.Stage.Model
{
    public class StageInfoDataModel : IStageInfoDataModel, IDisposable
    {
        private IStageInfoDataContext _stageInfoDataContext;
        private ILocalResourceFileLoadContext _localResourceFileLoadContext;
        private IExternalConnectContext _externalConnectContext;

        private string _currentSelectedStageID = string.Empty;
        private CompositeDisposable _subscriptions = new CompositeDisposable();

        public IObservable<IReadOnlyList<IStageInfoData>> OnStageInfoDataListChanged 
            => _stageInfoDataContext.OnListChanged;

        public IObservable<IStageInfoData> OnLatestStageChanged
            => _stageInfoDataContext.OnLatestStageChanged;

        public IStageInfoData CurrentSelectedStage { get; private set; }

        public IStageInfoData CurrentLatestStage 
            => _stageInfoDataContext.CurrentLatestStage;

        private Subject<IReadOnlyList<IStageInfoData>> _onCurrentAvaliableStageList = new Subject<IReadOnlyList<IStageInfoData>>();
        public IObservable<IReadOnlyList<IStageInfoData>> OnCurrentAvaliableStageList => _onCurrentAvaliableStageList;

        public StageInfoDataModel( IStageInfoDataContext stageInfoDataContext,
            ILocalResourceFileLoadContext localResourceFileLoadContext,
            IExternalConnectContext externalConnectContext)
        {
            _stageInfoDataContext = stageInfoDataContext;
            _localResourceFileLoadContext = localResourceFileLoadContext;
            _externalConnectContext = externalConnectContext;

            _stageInfoDataContext.OnLatestStageChanged
                .Subscribe( arg => FilterStageInfoList( arg ) )
                .AddTo( _subscriptions );
        }

        public async UniTask Initialize()
        {
            var path = new HandTablePath();
            var rawDataOperation = _localResourceFileLoadContext.GetTableRawData( path.StageDataMock );

            if( _stageInfoDataContext.List.Any() == false )
            {
                _stageInfoDataContext.SetStageInfoByTable( rawDataOperation.Value );
            }
        }

        public async UniTask LoadNewPlayableStageInfoData()
        {
            var id = await _externalConnectContext.GetClaeredStageID();
            _stageInfoDataContext.CheckCurrentStageInfo( id );
        }

        private void FilterStageInfoList(IStageInfoData data)
        {
            var list = _stageInfoDataContext.List
                .Where( arg => arg.WorldID.Equals( data.WorldID ) && arg.AreaID.Equals( data.AreaID ) )
                .ToList();
            var msg = string.Join("\n", list.Select(arg=> $"{arg.ID} : {arg.IsBossStage}"));
            _onCurrentAvaliableStageList.OnNext( list );
        }

        public void Dispose()
        {
            if( _subscriptions != null )
            {
                _subscriptions.Dispose();
                _subscriptions = null;
            }
        }

        public void SetCurrentSelectedStageID( string id )
        {
            CurrentSelectedStage = _stageInfoDataContext.List
                .First( arg => arg.ID.Equals( id ) );
        }
    }
}
