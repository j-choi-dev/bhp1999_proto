using CoreAssetUI.View;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Sound;

namespace CoreAssetUI.Presenter
{
    public class BattleScenePresenter : MonoBehaviour
    {
        private IHandDeckListView _handDeckListView;
        private IBattleInfoView _battleInfoView;
        private ICardDeckModel _cardDeckModel;
        private IGameSoundController _gameSoundController;
        private IGameRuleModel _gameRuleModel;
        private IBattleResourceConfig _config;

        [Inject]
        public void Initialize( IHandDeckListView handDeckListView,
            IBattleInfoView battleInfoView,
            ICardDeckModel cardDeckModel,
            IGameSoundController gameSoundController,
            IGameRuleModel gameRuleModel,
            IBattleResourceConfig config )// TODO к└кс@Choi
        {
            _handDeckListView = handDeckListView;
            _battleInfoView = battleInfoView;

            _cardDeckModel = cardDeckModel;
            _gameSoundController = gameSoundController;
            _gameRuleModel = gameRuleModel;
            _config = config;
        }

        private void Awake()
        {
            _gameSoundController.PlayEffect( "eff003" );
            _cardDeckModel.OnCurrentHandCardListChanged
                .Subscribe( list =>
                {
                    UpdateView( list );
                } )
                .AddTo( this );
            _cardDeckModel.OnCardListChanged
                .Subscribe( list =>
                {
                    Debug.Log( $"_cardDeckModel.OnCardListChanged {list.Count}" );
                } )
                .AddTo( this );

            _gameRuleModel.OnHandChanged
                .Subscribe( arg => _battleInfoView.SetHandCountWithoutNotify( arg ) )
                .AddTo( this );

            _gameRuleModel.OnDiscardChanged
                .Subscribe( arg => _battleInfoView.SetDiscardCountWithoutNotify( arg ) )
                .AddTo( this );

            _gameRuleModel.OnGoldChanged
                .Subscribe( arg => _battleInfoView.SetGoldWithoutNotify( arg ) )
                .AddTo( this );

            _gameRuleModel.OnCircleValueChanged
                .Subscribe( arg => _battleInfoView.SetCircleWithoutNotify( arg ) )
                .AddTo( this );

            _gameRuleModel.OnManaValueChanged
                .Subscribe( arg => _battleInfoView.SetManaWithoutNotify( arg ) )
                .AddTo( this );
        }

        private async void Start()
        {
            await _cardDeckModel.Initialize();
            await _gameRuleModel.Initialize();

        }

        private void UpdateView(IReadOnlyList<IBattleCard> list)
        {
            _handDeckListView.Clear();
            for(int i = 0; i< list.Count; i++ )
            {
                var sprite = _config.GetIllustSprite( list[i].IllustResourceID );
                _handDeckListView.Add( list[i].ID, list[i].Value.ToString(), sprite.Value, false );
            }
        }
    }
}
