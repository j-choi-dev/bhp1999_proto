using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.Stage.Domain
{
    public interface IStageInfoListDomain
    {
        IObservable<IStageInfoData> OnLatestStageChanged { get; }
        IStageInfoData CurrentLatestStage { get; }
        IReadOnlyList<IStageInfoData> List { get; }
        IObservable<IReadOnlyList<IStageInfoData>> OnListChanged { get; }

        void SetList( IReadOnlyList<IStageInfoData> list );
        void UpdateClearedStage( string id );
    }

    public class StageInfoListDomain : IStageInfoListDomain
    {
        private List<IStageInfoData> _list = new List<IStageInfoData>();
        public IReadOnlyList<IStageInfoData> List => _list;


        private Subject<IReadOnlyList<IStageInfoData>> _onListChanged = new Subject<IReadOnlyList<IStageInfoData>>();
        public IObservable<IReadOnlyList<IStageInfoData>> OnListChanged => _onListChanged;

        private Subject<IStageInfoData> _onLatestStageChanged = new Subject<IStageInfoData>();
        public IObservable<IStageInfoData> OnLatestStageChanged => _onLatestStageChanged;

        public IStageInfoData CurrentLatestStage { get; private set; }

        public void SetList( IReadOnlyList<IStageInfoData> list )
        {
            _list = list.ToList();
            _onListChanged.OnNext( _list );
            UpdateCurrentStage();
        }

        public void UpdateClearedStage( string id )
        {
            if(_list.Exists( arg => arg.ID.Equals( id ) ) == false )
            {
                return;
            }
            _list.Find( arg => arg.ID.Equals( id ) ).SetIsClear( true );
            _onListChanged.OnNext( _list );
            UpdateCurrentStage();
        }

        private void UpdateCurrentStage()
        {
            var index = _list.FindLastIndex( arg => arg.IsClear ) >= 0 ?
                _list.FindLastIndex( arg => arg.IsClear ) + 1 :
                0;
            CurrentLatestStage = _list[index];
            _onLatestStageChanged.OnNext( CurrentLatestStage );
        }
    }
}
