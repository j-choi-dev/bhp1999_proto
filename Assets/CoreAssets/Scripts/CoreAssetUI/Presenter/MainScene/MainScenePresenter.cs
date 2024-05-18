using GameSystemSDK.Common.Domain;
using UnityEngine;
using Zenject;
using GameSystemSDK.Common;
using Cysharp.Threading.Tasks;
using UniRx;
using System;
using GameSystemSDK.Sound;
using GameSystemSDK.Stage.Model;
using GameSystemSDK.Server.Model;

namespace CoreAssetUI.Presenter
{
    public class MainScenePresenter : MonoBehaviour
    {
        private IStageSelectModal _stageSelectModal;
        private IBattleEnterConfirmModal _battleEnterConfirmModal;
        private IGameSoundController _gameSoundController;
        private IStageInfoDataModel _stageInfoDataModel;
        private ISceneController _sceneController;
        private IExternalConnectModel _externalConnectModel;

        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( IStageSelectModal stageSelectModal,
            IBattleEnterConfirmModal battleEnterConfirmModal,
            IGameSoundController gameSoundController,
            IStageInfoDataModel stageInfoDataModel,
            ISceneController sceneController,
            IExternalConnectModel externalConnectModel )
        {
            _stageSelectModal = stageSelectModal;
            _battleEnterConfirmModal = battleEnterConfirmModal;
            _gameSoundController = gameSoundController;
            _stageInfoDataModel = stageInfoDataModel;
            _sceneController = sceneController;
            _externalConnectModel = externalConnectModel;
        }

        private async void Awake()
        {
            _sceneValueDomain = new SceneValueDomain();
            _gameSoundController.PlayBGM( "bgm002" );

            _stageSelectModal.OnButtonClick
                .Subscribe( stageId =>
                {
                    _stageInfoDataModel.SetCurrentSelectedStageID( stageId );
                    _battleEnterConfirmModal.SetDiscardCount( _stageInfoDataModel.CurrentSelectedStage.MaxDiscardCount.ToString() );
                    _battleEnterConfirmModal.SetPlayCount( _stageInfoDataModel.CurrentSelectedStage.MaxHandCount.ToString() );
                    _battleEnterConfirmModal.SetGoalScore( _stageInfoDataModel.CurrentSelectedStage.GoalScore.ToString() );
                    _battleEnterConfirmModal.SetGold( _stageInfoDataModel.CurrentSelectedStage.GoldValue.ToString() );
                    _battleEnterConfirmModal.SetActive( true );
                } )
                .AddTo( this );

            _battleEnterConfirmModal.OnPlayClick
                .Subscribe( async stageId =>
                {
                    _externalConnectModel.EnterStage( _stageInfoDataModel.CurrentSelectedStage.ID );

                    _gameSoundController.PlayEffect( "eff002" );
                    await UniTask.WaitUntil( () => _gameSoundController.IsPlayingEffect == false );
                    await _sceneController.LoadSceneAsync( _sceneValueDomain.BattleSceneName );
                } )
                .AddTo( this );

            _battleEnterConfirmModal.OnCloseClick
                .Subscribe( stageId =>
                {
                    _battleEnterConfirmModal.SetActive( false );
                } )
                .AddTo( this );

            _stageInfoDataModel.OnCurrentAvaliableStageList
                .Subscribe( list =>
                {
                    _stageSelectModal.SetStageInfoList( list );
                } )
                .AddTo( this );

            _stageInfoDataModel.OnLatestStageChanged
                .Subscribe( arg =>
                {
                    _stageSelectModal.SetWorldName( arg.WorldName );
                    _stageSelectModal.SetAreaName( arg.AreaName );
                    _stageSelectModal.SetGuage( 2 );
                } )
                .AddTo( this );

            _battleEnterConfirmModal.SetActive( false );
            await _stageInfoDataModel.Initialize();
        }

        private async void Start()
        {
            await _stageInfoDataModel.LoadNewPlayableStageInfoData();
        }
    }
}
