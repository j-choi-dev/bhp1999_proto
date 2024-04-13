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
        private ICardDeckModel _cardDeckModel;
        private IGameSoundController _gameSoundController;
        private IBattleResourceConfig _config;

        [Inject]
        public void Initialize( IHandDeckListView handDeckListView,
            ICardDeckModel cardDeckModel,
            IGameSoundController gameSoundController,
            IBattleResourceConfig config )// TODO к└кс@Choi
        {
            _handDeckListView = handDeckListView;
            _cardDeckModel = cardDeckModel;
            _gameSoundController = gameSoundController;
            _config = config;
        }

        private void Awake()
        {
            _gameSoundController.PlayEffect( "eff003" );
            _cardDeckModel.OnCurrentHandCardListChanged
                .Subscribe( list =>
                {
                    Debug.Log( $"_cardDeckModel.OnCurrentHandCardListChanged {list.Count}" );
                    UpdateView( list );
                } )
                .AddTo( this );
            _cardDeckModel.OnCardListChanged
                .Subscribe( list =>
                {
                    Debug.Log( $"_cardDeckModel.OnCardListChanged {list.Count}" );
                } )
                .AddTo( this );
        }

        private async void Start()
        {
            await _cardDeckModel.Initialize();

        }

        private void UpdateView(IReadOnlyList<IBattleCard> list)
        {
            Debug.Log( list.Count );
            _handDeckListView.Clear();
            for(int i = 0; i< list.Count; i++ )
            {
                var sprite = _config.GetIllustSprite( list[i].IllustResourceID );
                _handDeckListView.Add( list[i].ID, list[i].Value.ToString(), sprite.Value, false );
            }
        }
    }
}
