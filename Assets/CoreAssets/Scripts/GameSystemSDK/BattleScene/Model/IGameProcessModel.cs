using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// @Auth Choi
    /// 게임의 진행로직 및 게임 진행에 필요한 수치의 Model 클래스
    /// </summary>
    public interface IGameProcessModel
    {
        /// <summary>
        /// 잔여 핸드 카운트 변동 이벤트
        /// </summary>
        IObservable<int> OnHandChanged { get; }

        /// <summary>
        /// 잔여 카드 버리기 카운트 변동 이벤트
        /// </summary>
        IObservable<int> OnDiscardChanged { get; }

        /// <summary>
        /// 스테이지별 골드값 변동 이벤트
        /// </summary>
        IObservable<int> OnGoldChanged { get; }

        IObservable<int> OnGoalScoreChanged { get; }

        /// <summary>
        /// 스테이지별 Circle값 변동 이벤트
        /// </summary>
        IObservable<int> OnCircleValueChanged { get; }

        /// <summary>
        /// 스테이지별 Mana값 변동 이벤트
        /// </summary>
        IObservable<int> OnManaValueChanged { get; }

        /// <summary>
        /// 핸드 오버(=게이 오버) 이벤트
        /// </summary>
        IObservable<Unit> OnHandOver { get; }
        /// <summary>
        /// View에 표시할 스테이지 이름 변경 이벤트
        /// </summary>
        IObservable<string> OnStageNameChanged { get; }
        /// <summary>
        /// View에 표시할 스테이지 버프효과 1 변경 이벤트
        /// </summary>
        IObservable<string> OnStageBuff1Change { get; }
        /// <summary>
        /// View에 표시할 스테이지 버프효과 2 변경 이벤트
        /// </summary>
        IObservable<string> OnStageBuff2Change { get; }
        /// <summary>
        /// View에 표시할 스테이지 버프효과 3 변경 이벤트
        /// </summary>
        IObservable<string> OnStageBuff3Change { get; }
        /// <summary>
        /// Hand 점수 및 연출 관련 진행 플래그에 대한 이벤트
        /// </summary>
        IObservable<bool> OnHandProcessRun { get; }
        /// <summary>
        /// 점수계산이 끝났음을 알리는 이벤트
        /// </summary>
        IObservable<int> OnScoreChanged { get; }


        IObservable<Unit> OnShopDataChanged { get; }
        IObservable<Unit> OnCleareStage { get; }

        bool IsDiscardOver { get; }

        int CurrentHandCount { get; }
        int MaxHandCount { get; }
        int CurrentDiscardCount { get; }
        int CurrGold { get; }
        int GoalScore { get; }

        int CircleValue { get; }
        int ManaValue { get; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <returns>비동기 처리 UniTask</returns>
        UniTask Initialize();

        /// <summary>
        /// 핸드 실행
        /// </summary>
        /// <returns>비동기 처리 UniTask</returns>
        UniTask RunHand();

        void UpdateHandDeckInfo();

        void DiscardProcess( string id );

        /// <summary>
        /// 잔여 핸드 수 차감
        /// </summary>
        /// <param name="val">별도 지정이 없을 경우, Default값 1</param>
        void DiscountHandCount( int val = 1 );

        /// <summary>
        /// 카드 버리기 수 차감
        /// </summary>
        /// <param name="val">별도 지정이 없을 경우, Default값 1</param>
        void DiscountDiscardCount( int val );

        /// <summary>
        /// 스테이지별 실행 가능한 핸드 최대값 설정
        /// </summary>
        /// <param name="val">최대 핸드값(턴)</param>
        void SetMaxHandCount( int val );

        /// <summary>
        /// 스테이지별 실행 가능한 카드 버리기 최대값 설정
        /// </summary>
        /// <param name="val">최대 카드 버리기 회수</param>
        void SetMaxDiscardCount( int val );

        /// <summary>
        /// Gold값 설정
        /// </summary>
        /// <param name="val">Gold값</param>
        void SetGold( int val );

        void SetGoalScore( int val );

        /// <summary>
        /// Circle값 설정
        /// </summary>
        /// <param name="val">Circle값</param>
        void SetCircleValue( int value );

        /// <summary>
        /// Mana값 설정
        /// </summary>
        /// <param name="val">Mana값</param>
        void SetManaValue( int value );

        IReadOnlyList<IPlayingCardInfo> GetPlayingCardDeck( int DeckGroup );

        /// <summary>
        /// Game Finish Process
        /// </summary>
        /// <returns>UniTask Async Process</returns>
        UniTask GameFinishProcess();

        UniTask GameClearProcess();

        UniTask GetShopDataProcess();
    } 
}
