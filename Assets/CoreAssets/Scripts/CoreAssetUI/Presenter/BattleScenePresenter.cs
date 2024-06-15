using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Model;
using UnityEngine;
using Zenject;
using UniRx;
using GameSystemSDK.Sound;
using UnityEngine.UI;
using System.Linq;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

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
        private INoticeConfirmModal _noticeConfirmModal;
        private IResultModal _resultModal;
        private IShopModal _shopModal;
        private ICardListModel _cardDeckModel;
        private IGameSoundController _gameSoundController;
        private IGameProcessModel _gameProcessModel;
        private IBattleResourceModel _battleResourceModel;
        private IBattleEffectModel _battleEffectModel;
        private IBattleSceneActivationView _activationView;

        [Inject]
        public void Initialize( IHandDeckListView handDeckListView,
            ISelectedCardListView selectedCardListView,
            IBattleInfoView battleInfoView,
            IRunControlView runControlView,
            IBattleSceneActivationView activationView,
            INoticeConfirmModal noticeConfirmModal,
            IResultModal resultModal,
            IShopModal shopModal,
            ICardListModel cardDeckModel,
            IGameSoundController gameSoundController,
            IGameProcessModel gameProcessModel,
            IBattleResourceModel battleResourceModel,
            IBattleEffectModel battleEffectModel )
        {
            _handDeckListView = handDeckListView;
            _selectedCardListView = selectedCardListView;
            _battleInfoView = battleInfoView;
            _runControlView = runControlView;
            _activationView = activationView;
            _noticeConfirmModal = noticeConfirmModal;
            _resultModal = resultModal;
            _shopModal = shopModal;

            _cardDeckModel = cardDeckModel;
            _gameSoundController = gameSoundController;
            _gameProcessModel = gameProcessModel;
            _battleResourceModel = battleResourceModel;
            _battleEffectModel = battleEffectModel;
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
            _noticeConfirmModal.Show( false );
            _battleInfoView.SetScorePlateOn( false );
            _resultModal.SetActive( false );
            _shopModal.SetActive( false );

            await _gameProcessModel.Initialize();
            await _cardDeckModel.Initialize( _gameProcessModel.GetPlayingCardDeck(1) );  // 임시로 1 셋팅
            
            UpdateView();

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
                    _gameProcessModel.UpdateHandDeckInfo();
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
                        _gameProcessModel.CurrentDiscardCount > 0 );
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
                    _gameProcessModel.UpdateHandDeckInfo();
                } )
                .AddTo( this );

            _runControlView.OnHandPlayButton
                .Subscribe( async _ => await _gameProcessModel.RunHand() )
                .AddTo( this );

            _runControlView.OnDiscardButton
                .Subscribe( _ => _gameProcessModel.DiscardProcess( _handDeckListView.CurrentSelectedID ) )
                .AddTo( this );

            _noticeConfirmModal.OnConfirmClick
                .Subscribe( _ =>
                {
                    _gameProcessModel.GameFinishProcess().Forget();
                } )
                .AddTo( this );

            _resultModal.OnConfirm
                .Subscribe( _ =>
                {
                    _shopModal.SetActive( true );
                    _resultModal.SetActive(false);
                } )
                .AddTo( this );

            _shopModal.OnGoToNextStage
                .Subscribe( _ => _gameProcessModel.GameClearProcess().Forget() )
                .AddTo( this );
        }

        private void SubscribeModel()
        {
            _cardDeckModel.OnCardListChanged
                .Subscribe( _ => UpdateView() )
                .AddTo( this );

            _cardDeckModel.OnCurrentHandCardListChanged
                .Subscribe( _ => UpdateView() )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardAdd
                .Subscribe( item =>
                {
                    var sprite = _battleResourceModel.GetIllustSprite( item.PlayingCardInfo.IllustResourceID );
                    _selectedCardListView.Add( item.PlayingCardInfo.ID.ToString(), 
                        item.PlayingCardInfo.Chip.ToString(), 
                        sprite, 
                        false );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentHandCardListAdd
                .Subscribe( item =>
                {
                    var sprite = _battleResourceModel.GetIllustSprite( item.PlayingCardInfo.IllustResourceID );
                    _handDeckListView.Add( item.PlayingCardInfo.ID.ToString(), 
                        item.PlayingCardInfo.Chip.ToString(), 
                        sprite, 
                        false );
                } )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardRemoved
                .Subscribe( item => _selectedCardListView.Remove( item.PlayingCardInfo.ID.ToString() ) )
                .AddTo( this );

            _cardDeckModel.OnSelectedCardClear
                .Subscribe( item => _selectedCardListView.Clear() )
                .AddTo( this );

            _cardDeckModel.OnCurrentSelectedCardListChanged
                .Subscribe( list => _runControlView.SetHandPlayInteractable( list.Count > 0 ) )
                .AddTo( this );

            _gameProcessModel.OnHandChanged
                .Subscribe( count => UpdateView() )
                .AddTo( this );

            _gameProcessModel.OnDiscardChanged
                .Subscribe( _ => UpdateView() )
                .AddTo( this );

            _gameProcessModel.OnGoldChanged
                .Subscribe( arg => _battleInfoView.SetGoldWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnGoalScoreChanged
                .Subscribe( arg => _battleInfoView.SetGoalScoreWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnCircleValueChanged
                .Subscribe( arg => _battleInfoView.SetCircleWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnManaValueChanged
                .Subscribe( arg => _battleInfoView.SetManaWithoutNotify( arg ) )
                .AddTo( this );

            _gameProcessModel.OnHandOver
                .Subscribe( _ =>
                {
                    var message = new UIMessageData();
                    _noticeConfirmModal.SetHeaderTitleWithoutNotify( message.GameOverHader );
                    _noticeConfirmModal.SetMessageWithoutNotify( message.GameOverMessage );
                    _noticeConfirmModal.SetConfirmButtonWithoutNotify( message.Confirm );
                    _noticeConfirmModal.Show( true );
                } )
                .AddTo( this );

            _gameProcessModel.OnHandProcessRun
                .Subscribe( isLock =>
                {
                    _runControlView.SetHandPlayInteractable( isLock == false );
                    _runControlView.SetDiscardInteractable( isLock == false );
                    _selectedCardListView.SetItemsInteractable( isLock == false );
                    _handDeckListView.SetItemsInteractable( isLock == false );
                } )
                .AddTo( this );

            _gameProcessModel.OnScoreChanged
                .Subscribe( score => _battleInfoView.SetScorePercentageWithoutNotify( score ) )
                .AddTo( this );

            _gameProcessModel.OnCleareStage
                .Subscribe( _ => SetGameClearViewState() )
                .AddTo( this );

            _gameProcessModel.OnShopDataChanged
                .Subscribe( _ =>
                {
                    _resultModal.SetActive( false );
                    _shopModal.SetActive( true );
                } )
                .AddTo( this );

            _battleEffectModel.OnIsEffectProccess
                .Subscribe( isOn => _battleInfoView.SetScorePlateOn( isOn ) )
                .AddTo( this );

            _battleEffectModel.OnScoreInfoChanged
                .Subscribe( tupple =>
                {
                    _selectedCardListView.SetScoreEffect( tupple.index, tupple.score ).Forget();
                } )
                .AddTo( this );

            _battleEffectModel.OnSkillNameChanged
                .Subscribe( msg => _battleInfoView.SetScorePlateWithoutNotify( msg ) )
                .AddTo( this );
        }

        private void UpdateView()
        {
            var list = _cardDeckModel.CurrentHandDeckList;
            _handDeckListView.Clear();
            for( int i = 0; i< _cardDeckModel.CurrentHandDeckList.Count; i++ )
            {
                var sprite = _battleResourceModel.GetIllustSprite( list[i].PlayingCardInfo.IllustResourceID );
                _handDeckListView.Add( list[i].PlayingCardInfo.ID.ToString(), list[i].PlayingCardInfo.Chip.ToString(), sprite, false );
            }
            _runControlView.SetDiscardInteractable( false );
            _battleInfoView.SetHandCountWithoutNotify( _gameProcessModel.CurrentHandCount );
            _battleInfoView.SetDiscardCountWithoutNotify( _gameProcessModel.CurrentDiscardCount );
            _battleInfoView.SetDeckCountWithoutNotify( _cardDeckModel.CurrentUsableList.Count(), _cardDeckModel.AllDeckList.Count() );

            _runControlView.SetHandPlayInteractable( _gameProcessModel.CurrentHandCount > 0 && 
                _cardDeckModel.CurrentSelectedCardList.Count > 0 );
            _runControlView.SetDiscardInteractable( _gameProcessModel.CurrentDiscardCount > 0 
                && string.IsNullOrEmpty(_handDeckListView.CurrentSelectedID ) == false );
        }

        private void SetGameClearViewState()
        {
            _activationView.SetActive( false );
            _resultModal.SetActive( true );
        }
    }
}
