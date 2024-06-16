using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Infrastructure;
using GameSystemSDK.Common;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Server.Application;
using System;
using System.Collections.Generic;
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
        private IExternalConnectContext _externalConnectContext;

        private IStageInfoData _stageInfoData;
        private SceneValueDomain _sceneValueDomain;
        private int _currTotalScore = 0;

        public GameProcessModel( IGameRuleValueCntext gameRuleValueCntext,
            ICardListContext cardListContext,
            IHandCardListContext handCardListContext,
            ISelectedCardListContext selectedListContext,
            IBattleInfoContext battleInfoImporterContext,
            IBattleResourceContext battleResourceContext,
            IHandScoreCalcurateContext handScoreCalcurateContext,
            IBattleEffectContext battleEffectContext,
            ISceneController sceneController,
            IExternalConnectContext externalConnectContext )
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
            _externalConnectContext = externalConnectContext;

            _sceneValueDomain = new SceneValueDomain();
        }

        public IObservable<int> OnHandChanged => _gameRuleValueCntext.OnHandChanged;
        public IObservable<int> OnDiscardChanged => _gameRuleValueCntext.OnDiscardChanged;
        public IObservable<int> OnGoalScoreChanged => _gameRuleValueCntext.OnGoalScoreChanged;
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

        private Subject<Unit> _onCleareStage = new Subject<Unit>();
        public IObservable<Unit> OnCleareStage => _onCleareStage;

        private Subject<Unit> _onShopDataChanged = new Subject<Unit>();
        public IObservable<Unit> OnShopDataChanged => _onShopDataChanged;

        public bool IsDiscardOver => _gameRuleValueCntext.IsDiscardOver;

        public int CurrentHandCount => _gameRuleValueCntext.CurrentHandCount;

        public int MaxHandCount => _gameRuleValueCntext.MaxHandCount;
        public int CurrentDiscardCount => _gameRuleValueCntext.CurrentDiscardCount;

        public int CurrGold => _gameRuleValueCntext.CurrGold;
        public int GoalScore => _gameRuleValueCntext.GoalScore;

        public int CircleValue => _gameRuleValueCntext.CircleValue;

        public int ManaValue => _gameRuleValueCntext.ManaValue;

        public void DiscountDiscardCount( int val = 1 ) => _gameRuleValueCntext.DiscountDiscardCount( val );

        public void DiscountHandCount( int val = 1 ) => _gameRuleValueCntext.DiscountHandCount( val );

        public void SetCircleValue( int value ) => _gameRuleValueCntext.SetCircleValue( value );
        public void SetGold( int val ) => _gameRuleValueCntext.SetGold( val );
        public void SetGoalScore( int val ) => _gameRuleValueCntext.SetGoalScore( val );
        public void SetManaValue( int value ) => _gameRuleValueCntext.SetManaValue( value );
        public void SetMaxHandCount( int val ) => _gameRuleValueCntext.SetMaxHandCount( val );
        public void SetMaxDiscardCount( int val ) => _gameRuleValueCntext.SetMaxDiscardCount( val );
        public IReadOnlyList<IPlayingCardInfo> GetPlayingCardDeck()
        {
            var cardList = _externalConnectContext.GetCardInfo();

            // <TODO>
            // 임시로 넣어놨다.
            // 최초 플레이어 정보 생성할 때는 거기에 맞게 넣어준다.
            // 여기에 있을 부분은 아님.
            if (cardList.Count == 0)
            {
                var playingCardList = _battleInfoContext.GetPlayingCardDeck(1);
                _externalConnectContext.SetCardInfo( playingCardList );

                cardList = _externalConnectContext.GetCardInfo();
            }

            return _battleInfoContext.GetPlayingCardDeckByList( cardList );
        }

        public async UniTask Initialize()
        {
            var id = await _externalConnectContext.GetStageID();

            var path = new HandTablePath();
            var rawData = _battleResourceContext.GetTableRawData( path.StageDataMock );
            var battleInfoImportOperation = await _battleInfoContext.LoadStageInfo(rawData.Value);
            //if( battleInfoImportOperation.IsSuccess != false )
            //{
            //    UnityEngine.Debug.LogError( battleInfoImportOperation.ErrorMessage );
            //}
            _stageInfoData = _battleInfoContext.GetStageInfo(id);

            SetMaxHandCount( _stageInfoData.MaxHandCount );
            SetMaxDiscardCount( _stageInfoData.MaxDiscardCount );
            SetGold( _stageInfoData.GoldValue );
            SetGoalScore( _stageInfoData.GoalScore );
            SetCircleValue( 0 );
            SetManaValue( 0 );

            _onStageNameChanged.OnNext( _stageInfoData.StageName );

            await InitGame();
        }

        // <TODO>
        // 게임(스테이지의 묶음) 최초로 시작되었을 때 실행될 함수
        // 현재는 이걸 게임 프로세스 모델 Initialize에서 부르고 있는데 게임 최초로 시작될 때로 옮겨야 한다
        public async UniTask InitGame()
        {
            await InitializeGameRuleData();
        }

        // <TODO>
        // 카드 변경 시에도 족보 보이도록 작업 필요
        public void UpdateHandDeckInfo()
        {
            var handList = _battleInfoContext.HandInfoDataList;
            var scoreTupple = _handScoreCalcurateContext.GetMaxPokerScore(handList, _selectedListContext.List);
            var handsLevel = _externalConnectContext.GetHandLevel(scoreTupple.id);
            var conditionInfo = _handScoreCalcurateContext.GetPokerHandsInfoByID( handList, scoreTupple.id, handsLevel);
            _battleEffectContext.SelectHandProcess(conditionInfo);
        }

        public async UniTask RunHand()
        {
            _onHandProcessRun.OnNext( true );
            var handList = _battleInfoContext.HandInfoDataList;
            var scoreTupple = _handScoreCalcurateContext.GetMaxPokerScore( handList, _selectedListContext.List );
            var handsLevel = _externalConnectContext.GetHandLevel(scoreTupple.id);
            var conditionInfo = _handScoreCalcurateContext.GetPokerHandsInfoByID( handList, scoreTupple.id, handsLevel);

            // 임시 코드들...
            await UniTask.Delay(500);
            var soundEffectId = $"battle00{UnityEngine.Random.Range(1, 5)}";
            var clip = _battleResourceContext.GetSoundEffectData(soundEffectId);
            // <TODO> 만약 여기서 핸드에 제출한 카드가 모두 트리거되는 조커를 쓴다면 scoreTupple.Item2가 아닌 handList를 넣어야 한다.
            // <TODO> 제출한 카드를 하나씩 트리거하는 루틴.
            // <TODO> 추후 손에 남은 카드, 조커 순으로 카드가 트리거되도록 작업한다.
            var scoreInfo = _handScoreCalcurateContext.GetScoreData(conditionInfo);
            await _battleEffectContext.RunScoreEffectProcess(scoreInfo, clip.Value);
            for (int scoreHandIdx = 0; scoreHandIdx < scoreTupple.Item2.Count; scoreHandIdx++ )
            {
                await UniTask.Delay(1500);
                scoreInfo.AddSummitScoreData( scoreTupple.Item2[scoreHandIdx]);
                _battleEffectContext.RunScoreNextEffectProcess(scoreInfo, scoreHandIdx);
            }

            await UniTask.Delay( 1000 );
            _currTotalScore += scoreInfo.GetScore();
            if( _currTotalScore >= _stageInfoData.GoalScore )
            {
                UnityEngine.Debug.Log( "Stage Clear" );
                await _externalConnectContext.SetClearedStageInfo( _stageInfoData.ID );
                _onCleareStage.OnNext( Unit.Default );
            }
            _onScoreChanged.OnNext(scoreInfo.GetScore());

            await UniTask.Delay( 1000 );
            _cardListContext.SetIsDrawn( _selectedListContext.List.Select( arg => arg.ID ).ToList() );
            _selectedListContext.Clear();
            _handCardListContext.UpdateList( _cardListContext.AllList );
            DiscountHandCount();

            _battleEffectContext.RunScoreEndEffectProcess();


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

        public async UniTask GameClearProcess()
        {
            await _sceneController.LoadSceneAsync( _sceneValueDomain.MainSceneName );
        }

        /// <Todo>
        /// 이 함수는 어플리케이션 켜질 때 한번만 로딩하면 될 것 같습니다.
        /// </Todo>
        private async UniTask InitializeGameRuleData()
        {
            var path = new HandTablePath();
            var handConditionRawData = _battleResourceContext.GetTableRawData( path.PokerHandsConditionCsvName );
            _battleInfoContext.InitHandConditionDataList( handConditionRawData.Value );

            var handRawData = _battleResourceContext.GetTableRawData( path.PokerHandsCsvName );
            _battleInfoContext.InitHandDataList( handRawData.Value );

            var handLevelRawData = _battleResourceContext.GetTableRawData(path.PokerHandsLevelCsvName);
            _battleInfoContext.InitHandLevelDataList(handLevelRawData.Value);

            var playingCardRawData = _battleResourceContext.GetTableRawData(path.PlayingCardCsvName);
            _battleInfoContext.InitPlayingCardListStorageDomain(playingCardRawData.Value);

            var cardUpgradeRawData = _battleResourceContext.GetTableRawData(path.CardUpgradeCsvName);
            _battleInfoContext.InitCardUpgradeStorageDomain(cardUpgradeRawData.Value);

            var cardEffectRawData = _battleResourceContext.GetTableRawData(path.CardEffectCsvName);
            _battleInfoContext.InitCardEffectStorageDomain(cardEffectRawData.Value);

            await UniTask.Delay( 1 );

        }

        public async UniTask GetShopDataProcess()
        {
            UnityEngine.Debug.Log( "상점에 표시할 데이터 취득 @Choi" );
            await UniTask.Delay( 500 );
            _onShopDataChanged.OnNext(Unit.Default);
        }
    }
}
