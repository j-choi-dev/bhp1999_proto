using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Model
{
    public class GameProcessModel : IGameProcessModel
    {
        private IGameRuleValueCntext _gameRuleValueCntext;
        private ICardListContext _cardListContext;
        private IHandCardListContext _handCardListContext;
        private IBattleInfoImporterContext _battleInfoImporterContext;

        public GameProcessModel( IGameRuleValueCntext gameRuleValueCntext,
            ICardListContext cardListContext,
            IHandCardListContext handCardListContext,
            IBattleInfoImporterContext battleInfoImporterContext )
        {
            _gameRuleValueCntext = gameRuleValueCntext;
            _cardListContext = cardListContext;
            _handCardListContext = handCardListContext;
            _battleInfoImporterContext = battleInfoImporterContext;
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

        public bool IsDiscardOver => _gameRuleValueCntext.IsDiscardOver;

        public int CurrHandCount => _gameRuleValueCntext.CurrHandCount;

        public int MaxHandCount => _gameRuleValueCntext.MaxHandCount;
        public int CurrDiscardCount => _gameRuleValueCntext.CurrDiscardCount;

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
            var battleInfoImportOperation = await _battleInfoImporterContext.LoadBattleInfo();
            //if( battleInfoImportOperation.IsSuccess != false )
            //{
            //    UnityEngine.Debug.LogError( battleInfoImportOperation.ErrorMessage );
            //}
            var info = _battleInfoImporterContext.GetBattleInfo(mock);

            SetMaxHandCount( info.MaxHandCount );
            SetMaxDiscardCount( info.MaxDiscardCount );
            SetGold( info.GoldValue );
            SetCircleValue( 0 );
            SetManaValue( 0 );

            _onStageNameChanged.OnNext( info.StageName );
            _onStageBuff1Change.OnNext( info.StageBuff1 );
            _onStageBuff2Change.OnNext( info.StageBuff2 );
            _onStageBuff3Change.OnNext( info.StageBuff3 );
        }

        public async UniTask RunHand()
        {
            DiscountHandCount();
            await UniTask.Delay( 500 );
            Debug.Log( "족보연산" );
            await UniTask.Delay( 500 );
            Debug.Log( "이펙트 연출" );
            await UniTask.Delay( 250 );
            Debug.Log( "데미지 차감" );
            await UniTask.Delay( 250 );
            Debug.Log( "종료" );
        }

        public void DiscardProcess( string id )
        {
            if( string.IsNullOrEmpty( id ) )
            {
                return;
            }
            _cardListContext.AllList.ToList().Find( arg => arg.ID.Equals( id ) ).SetDrawn( true );
            var card = _cardListContext.GetCard(id);
            Debug.Log( $"card : {card.ID}, {card.IsDrawn}" );
            _handCardListContext.Remove( card );
            DiscountDiscardCount();
            _handCardListContext.UpdateList( _cardListContext.AllList );
        }
    }
}
