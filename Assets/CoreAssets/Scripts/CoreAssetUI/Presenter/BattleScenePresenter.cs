using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Model;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Sound;
using UnityEngine.UI;
using System.Linq;

namespace CoreAssetUI.Presenter
{
    public class BattleScenePresenter : MonoBehaviour
    {
        [SerializeField] Image _image;
        [SerializeField] TMPro.TMP_Text _text;
        private IHandDeckListView _handDeckListView;
        private ISelectedCardListView _selectedCardListView;
        private IBattleInfoView _battleInfoView;
        private IRunControlView _runControlView;
        private ICardListModel _cardDeckModel;
        private IGameSoundController _gameSoundController;
        private IGameProcessModel _gameProcessModel;
        private IBattleResourceConfig _config;

        [Inject]
        public void Initialize( IHandDeckListView handDeckListView,
            ISelectedCardListView selectedCardListView,
            IBattleInfoView battleInfoView,
            IRunControlView runControlView,
            ICardListModel cardDeckModel,
            IGameSoundController gameSoundController,
            IGameProcessModel gameProcessModel,
            IBattleResourceConfig config )// TODO к└кс@Choi
        {
            _handDeckListView = handDeckListView;
            _selectedCardListView = selectedCardListView;
            _battleInfoView = battleInfoView;
            _runControlView = runControlView;

            _cardDeckModel = cardDeckModel;
            _gameSoundController = gameSoundController;
            _gameProcessModel = gameProcessModel;
            _config = config;
        }

        private void Awake()
        {
            _image.gameObject.SetActive( false );
            _text.text = string.Empty;
            _gameSoundController.PlayEffect( "eff003" );

            SubscribeView();
            SubscribeModel();
        }

        private async void Start()
        {
            await _cardDeckModel.Initialize();
            await _gameProcessModel.Initialize();

        }

        private void SubscribeView()
        {
            _handDeckListView.OnSelectionIDChanged
                .Subscribe( arg =>
                {
                    if( arg.isSelected == false )
                    {
                        return;
                    }
                    _cardDeckModel.MoveToSelectedList( arg.id );
                } )
                .AddTo( this );

            _handDeckListView.OnCurrentSelectionIDChanged
                .Subscribe( arg =>
                {
                    if( string.IsNullOrEmpty( arg.id ) == false &&
                        arg.isSelected == false )
                    {
                        _runControlView.SetDiscardInteractable( false );
                        return;
                    }
                    _runControlView.SetDiscardInteractable( arg.isSelected && 
                        _gameProcessModel.CurrDiscardCount > 0 );
                } )
                .AddTo( this );

            _selectedCardListView.OnSelectionIDChanged
                .Subscribe( arg =>
                {
                    if( arg.isSelected == false )
                    {
                        return;
                    }
                    _cardDeckModel.ReturnToHandList( arg.id );
                } )
                .AddTo( this );

            _runControlView.OnHandPlayButton
                .Subscribe( async _ =>
                {
                    Debug.Log( "OnHandPlayButton" );
                    await _gameProcessModel.RunHand();
                } )
                .AddTo( this );

            _runControlView.OnDiscardButton
                .Subscribe( _ =>
                {
                    Debug.Log( "OnDiscardButton" );
                    _gameProcessModel.DiscardProcess( _handDeckListView.CurrentSelectedID );
                } )
                .AddTo( this );
        }

        private void SubscribeModel()
        {
            _cardDeckModel.OnCurrentHandCardListChanged
                .Subscribe( list =>
                {
                    UpdateView( list );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardAdd
                .Subscribe( item =>
                {
                    var sprite = _config.GetIconSprite( item.IconResourceID );
                    _selectedCardListView.Add( item.ID, item.Value.ToString(), sprite.Value, false );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentHandCardListAdd
                .Subscribe( item =>
                {
                    var sprite = _config.GetIllustSprite( item.IllustResourceID );
                    _handDeckListView.Add( item.ID, item.Value.ToString(), sprite.Value, false );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardRemoved
                .Subscribe( item =>
                {
                    _selectedCardListView.Remove( item.ID );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardListChanged
                .Subscribe( list =>
                {
                    _runControlView.SetHandPlayInteractable( list.Count > 0 );
                } )
                .AddTo( this );

            _gameProcessModel.OnHandChanged
                .Subscribe( count =>
                {
                    UpdateView( _cardDeckModel.CurrentHandDeckList );
                    _battleInfoView.SetHandCountWithoutNotify( count );
                } )
                .AddTo( this );

            _gameProcessModel.OnDiscardChanged
                .Subscribe( count =>
                {
                    UpdateView( _cardDeckModel.CurrentHandDeckList );
                } )
                .AddTo( this );

            _gameProcessModel.OnGoldChanged
                .Subscribe( arg => _battleInfoView.SetGoldWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnCircleValueChanged
                .Subscribe( arg => _battleInfoView.SetCircleWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnManaValueChanged
                .Subscribe( arg => _battleInfoView.SetManaWithoutNotify( arg ) )
                .AddTo( this );
        }

        private void UpdateView( IReadOnlyList<IBattleCard> list )
        {
            _handDeckListView.Clear();
            for( int i = 0; i< list.Count; i++ )
            {
                var sprite = _config.GetIllustSprite( list[i].IllustResourceID );
                _handDeckListView.Add( list[i].ID, list[i].Value.ToString(), sprite.Value, false );
            }
            _runControlView.SetDiscardInteractable( false );
            _battleInfoView.SetHandCountWithoutNotify( _gameProcessModel.CurrHandCount );
            _battleInfoView.SetDiscardCountWithoutNotify( _gameProcessModel.CurrDiscardCount );
        }
    }
}
