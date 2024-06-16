using CoreAssetUI.View;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace CoreAssetUI.Presenter
{
    public class BattleSceneCardPresenter : MonoBehaviour
    {
        private ICardBoardView _playDeckListView;
        private ISelectedBoardView _selectedDeckListView;

        private IBattleCardModel _battleCardModel;
        private IBattleResourceModel _battleResourceModel;

        [Inject]
        public void Initialize( ICardBoardView handDeckListView,
            ISelectedBoardView selectedDeckListView,
            IBattleCardModel battleCardModel,
            IBattleResourceModel battleResourceModel )
        {
            _playDeckListView = handDeckListView;
            _selectedDeckListView = selectedDeckListView;
            _battleCardModel = battleCardModel;
            _battleResourceModel = battleResourceModel;
        }

        private async void Awake()
        {
            _playDeckListView.SetMaxSelectionCount( _battleCardModel.MaxSelectionCount );
            SubscribeView();
            SubscribeModel();
            await _battleCardModel.Initialize();
        }

        private void SubscribeView()
        {
            _playDeckListView.OnCurrentSelectionIDChanged
                .Subscribe( tupple => SetSelectCardList( tupple.id, tupple.isSelected ) )
                .AddTo( this );
        }

        private void SubscribeModel()
        {
            _battleCardModel.OnPlayingCardAdd
                .Subscribe( card => AddPlayDeckCard( card ) )
                .AddTo( this );
        }

        private void SetPlayDeckList( IReadOnlyList<ICellBase> list )
        {

        }

        private void PlayDeckListClear()
        {

        }

        private void AddPlayDeckCard( IBattleCard data )
        {
            var illust = _battleResourceModel.GetIllustSprite( data.PlayingCardInfo.IllustResourceID );
            _playDeckListView.Add( data.PlayingCardInfo.ID.ToString(), illust, true );
        }

        private void RemovePlayDeckCard( string id )
        {

        }

        private void SetSelectCardList( string id, bool isSelected )
        {
            if(isSelected)
            {
                _battleCardModel.AddSelectedCard( id );
            }
            else
            {
                _battleCardModel.RemoveSelectedCard( id );
            }
        }

        private void SelectedCardClear()
        {

        }

        private void AddSelectedCard( IBattleCard data )
        {

        }
        private void RemoveSelectedCard( string id )
        {

        }
    }
}
