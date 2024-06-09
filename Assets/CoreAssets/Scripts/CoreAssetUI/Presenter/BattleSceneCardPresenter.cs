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
        private IListView _handDeckListView;
        private IListView _selectedDeckListView;

        private IBattleCardModel _battleCardModel;

        [Inject]
        public void Initialize( [Inject( Id = BindingID.HandDeckListView )] IListView handDeckListView,
            [Inject(Id = BindingID.SelectedListView )] IListView selectedDeckListView,
            IBattleCardModel battleCardModel)
        {
            _handDeckListView = handDeckListView;
            _selectedDeckListView = selectedDeckListView;
            _battleCardModel = battleCardModel;
        }

        private void Awake()
        {
            SubscribeView();
            SubscribeModel();
        }

        private void SubscribeView()
        {
            _handDeckListView.OnCurrentSelectionIDChanged
                .Subscribe( tupple => SetSelectCardList( tupple.id, tupple.isSelected ) )
                .AddTo( this );
        }

        private void SubscribeModel()
        {

        }

        private void SetHandList( IReadOnlyList<ICellBase> list )
        {

        }

        private void HandListClear()
        {

        }

        private void AddHandCard( IBattleCard data )
        {

        }
        private void RemoveHandCard( string id )
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
