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
using UnityEngine.UI;

namespace CoreAssetUI.Presenter
{
    public class BattleScenePresenter : MonoBehaviour
    {
        [SerializeField] Image _image;
        [SerializeField] TMPro.TMP_Text _text;
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
            _image.gameObject.SetActive( false );
            _text.text = string.Empty;
            _gameSoundController.PlayEffect( "eff003" );

            _handDeckListView.OnSelectionChanged
                .Subscribe( arg => Debug.Log( arg.id ) )
                .AddTo( this );

            _handDeckListView.OnDragStarted
                .Subscribe( tupple =>
                {
                    Debug.Log( $"OnDragStart : {tupple.id}, {tupple.pos}" );
                    if( _image.gameObject.activeSelf== false )
                    {
                        _image.gameObject.SetActive( true );
                        _text.text = tupple.id;
                    }
                    _image.rectTransform.anchoredPosition = tupple.pos;
                } )
                .AddTo( this );

            _handDeckListView.OnDragEnd
                .Subscribe( tupple =>
                {
                    Debug.Log( $"OnDragEnd : {tupple.id}, {tupple.pos}" );
                    if( _image.gameObject.activeSelf )
                    {
                        _text.text = string.Empty;
                        _image.gameObject.SetActive( false );
                    }
                    _image.rectTransform.anchoredPosition = tupple.pos;
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentHandCardListChanged
                .Subscribe( list =>
                {
                    UpdateView( list );
                } )
                .AddTo( this );
            _cardDeckModel.OnCardListChanged
                .Subscribe( list =>
                {
                    // Do Something @Choi
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
