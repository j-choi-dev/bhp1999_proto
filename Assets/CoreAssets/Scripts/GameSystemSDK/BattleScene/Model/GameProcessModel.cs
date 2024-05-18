using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common;
using GameSystemSDK.Common.Domain;
using System;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Model
{
    public class GameProcessModel : IGameProcessModel
    {
        private IGameRuleValueCntext _gameRuleValueCntext;
        private ICardListContext _cardListContext;
        private IHandCardListContext _handCardListContext;
        private ISelectedCardListContext _selectedListContext;
        private IBattleInfoContext _battleInfoContext;
        private IBattleResourceContext _battleResourceContext;
        private IHandScoreCalcurateContext _handScoreCalcurateContext;
        private IBattleEffectContext _battleEffectContext;
        private ISceneController _sceneController;

        private SceneValueDomain _sceneValueDomain;

        public GameProcessModel( IGameRuleValueCntext gameRuleValueCntext,
            ICardListContext cardListContext,
            IHandCardListContext handCardListContext,
            ISelectedCardListContext selectedListContext,
            IBattleInfoContext battleInfoImporterContext,
            IBattleResourceContext battleResourceContext,
            IHandScoreCalcurateContext handScoreCalcurateContext,
            IBattleEffectContext battleEffectContext,
            ISceneController sceneController)
        {
            _gameRuleValueCntext = gameRuleValueCntext;
            _cardListContext = cardListContext;
            _handCardListContext = handCardListContext;
            _selectedListContext = selectedListContext;
            _battleInfoContext = battleInfoImporterContext;
            _battleResourceContext = battleResourceContext;
            _handScoreCalcurateContext = handScoreCalcurateContext;
            _battleEffectContext = battleEffectContext;
            _sceneController = sceneController;

            _sceneValueDomain = new SceneValueDomain();
        }

        public IObservable<int> OnHandChanged => _gameRuleValueCntext.OnHandChanged;
        public IObservable<int> OnDiscardChanged => _gameRuleValueCntext.OnDiscardChanged;
        public IObservable<int> OnGoldChanged => _gameRuleValueCntext.OnGoldChanged;
        public IObservable<int> OnCircleValueChanged => _gameRuleValueCntext.OnCircleValueChanged;
        public IObservable<int> OnManaValueChanged => _gameRuleValueCntext.OnManaValueChanged;
        public IObservable<Unit> OnHandOver => _gameRuleValueCntext.OnHandOver;

        private Subject<string> _onStageNameChanged = new Subject<string>();
        public IObservable<string> OnStageNameChanged => _onStageNameChanged;

        private Subject<string> _onStageBuff1Change = new Subject<string>();
        public IObservable<string> OnStageBuff1Change => _onStageBuff1Change;

        private Subject<string> _onStageBuff2Change = new Subject<string>();
        public IObservable<string> OnStageBuff2Change => _onStageBuff2Change;

        private Subject<string> _onStageBuff3Change = new Subject<string>();
        public IObservable<string> OnStageBuff3Change => _onStageBuff3Change;

        private Subject<bool> _onHandProcessRun = new Subject<bool>();
        public IObservable<bool> OnHandProcessRun => _onHandProcessRun;

        private Subject<int> _onScoreChanged = new Subject<int>();
        public IObservable<int> OnScoreChanged => _onScoreChanged;

        public bool IsDiscardOver => _gameRuleValueCntext.IsDiscardOver;

        public int CurrentHandCount => _gameRuleValueCntext.CurrentHandCount;

        public int MaxHandCount => _gameRuleValueCntext.MaxHandCount;
        public int CurrentDiscardCount => _gameRuleValueCntext.CurrentDiscardCount;

        public int CurrGold => _gameRuleValueCntext.CurrGold;

        public int CircleValue => _gameRuleValueCntext.CircleValue;

        public int ManaValue => _gameRuleValueCntext.ManaValue;

        public void DiscountDiscardCount( int val = 1 ) => _gameRuleValueCntext.DiscountDiscardCount( val );

        public void DiscountHandCount( int val = 1 ) => _gameRuleValueCntext.DiscountHandCount( val );

        public void SetCircleValue( int value ) => _gameRuleValueCntext.SetCircleValue( value );
        public void SetGold( int val ) => _gameRuleValueCntext.SetGold( val );
        public void SetManaValue( int value ) => _gameRuleValueCntext.SetManaValue( value );
        public void SetMaxHandCount( int val ) => _gameRuleValueCntext.SetMaxHandCount( val );
        public void SetMaxDiscardCount( int val ) => _gameRuleValueCntext.SetMaxDiscardCount( val );

        public async UniTask Initialize()
        {
            var mock = UnityEngine.Random.Range(0, 9); // TODO @Choi 24.04.14

            var path = new HandTablePath();
            var rawData = _battleResourceContext.GetTableRawData( path.StageDataMock );
            var battleInfoImportOperation = await _battleInfoContext.LoadStageInfo(rawData.Value);
            //if( battleInfoImportOperation.IsSuccess != false )
            //{
            //    UnityEngine.Debug.LogError( battleInfoImportOperation.ErrorMessage );
            //}
            var info = _battleInfoContext.GetStageInfo(mock);

            SetMaxHandCount( info.MaxHandCount );
            SetMaxDiscardCount( info.MaxDiscardCount );
            SetGold( info.GoldValue );
            SetCircleValue( 0 );
            SetManaValue( 0 );

            _onStageNameChanged.OnNext( info.StageName );
            _onStageBuff1Change.OnNext( info.StageBuff1 );
            _onStageBuff2Change.OnNext( info.StageBuff2 );
            _onStageBuff3Change.OnNext( info.StageBuff3 );

            InitializeHandData();
        }

        public async UniTask RunHand()
        {
            _onHandProcessRun.OnNext( true );
            var list = _selectedListContext.List;
            var handList = _battleInfoContext.HandInfoDataList;
            var scoreTupple = _handScoreCalcurateContext.GetMaxPokerScore( handList, _selectedListContext.List );
            var conditionInfo = _handScoreCalcurateContext.GetPokerHandsInfoByID( handList, scoreTupple.id );
            var scoreInfo = _handScoreCalcurateContext.GetScoreData( _selectedListContext.List, conditionInfo );

            await UniTask.Delay( 500 );
            var soundEffectId = $"battle00{UnityEngine.Random.Range(1, 5)}";
            var clip = _battleResourceContext.GetSoundEffectData( soundEffectId );
            await _battleEffectContext.RunScoreEffectProcess( scoreInfo, clip.Value );

            await UniTask.Delay( 250 );
            //UnityEngine.Debug.Log( "데미지 차감? - // TODO 미구현 @Choi" );
            _onScoreChanged.OnNext( scoreInfo.Score );


            await UniTask.Delay( 250 );
            _cardListContext.SetIsDrawn( _selectedListContext.List.Select( arg => arg.ID ).ToList() );
            _selectedListContext.Clear();
            _handCardListContext.UpdateList( _cardListContext.AllList );
            DiscountHandCount();
            _onHandProcessRun.OnNext( false );
        }

        public void DiscardProcess( string id )
        {
            if( string.IsNullOrEmpty( id ) )
            {
                return;
            }
            _cardListContext.AllList.ToList().Find( arg => arg.ID.Equals( id ) ).SetDrawn( true );
            var card = _cardListContext.GetCard(id);
            UnityEngine.Debug.Log( $"card : {card.ID}, {card.IsDrawn}" );

            _handCardListContext.Remove( card );
            DiscountDiscardCount();
            _handCardListContext.UpdateList( _cardListContext.AllList );
        }

        public async UniTask GameFinishProcess()
        {
            await _sceneController.LoadSceneAsync( _sceneValueDomain.MainSceneName );
        }

        private async void InitializeHandData()
        {
            var path = new HandTablePath();
            var handConditionRawData = _battleResourceContext.GetTableRawData( path.PokerHandsConditionCsvName );
            _battleInfoContext.InitHandConditionDataList( handConditionRawData.Value );

            var handRawData = _battleResourceContext.GetTableRawData( path.PokerHandsCsvName );
            _battleInfoContext.InitHandDataList( handRawData.Value );

            var playingCardRawData = _battleResourceContext.GetTableRawData(path.PlayingCardCsvName);
            _battleInfoContext.InitPlayingCardListStorageDomain(playingCardRawData.Value);

            var cardUpgradeRawData = _battleResourceContext.GetTableRawData(path.CardUpgradeCsvName);
            _battleInfoContext.InitCardUpgradeStorageDomain(cardUpgradeRawData.Value);

            var cardEffectRawData = _battleResourceContext.GetTableRawData(path.CardEffectCsvName);
            _battleInfoContext.InitCardEffectStorageDomain(cardEffectRawData.Value);

            await UniTask.Delay( 1 );

        }
    }
}
