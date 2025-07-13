using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 게임 진행에 필요한 값(Rule)과 관련된 Domain
    /// @Auth Choi
    /// </summary>
    public interface IGameRuleValueDomain
    {
        /// <summary>
        /// 턴(Hand) 변경 통지
        /// </summary>
        IObservable<int> OnHandChanged { get; }
        /// <summary>
        /// 잔여 패 버리기(Discard) 변경 통지
        /// </summary>
        IObservable<int> OnDiscardChanged { get; }
        /// <summary>
        /// 클리어 보수(Gold) 변경 통지
        /// </summary>
        IObservable<int> OnGoldChanged { get; }
        /// <summary>
        /// Circle 값 변경 통지
        /// </summary>
        // TODO 추후 Circle의 활용 방법 사양을 Fix할 예정 @Choi
        IObservable<int> OnCircleValueChanged { get; }
        /// <summary>
        /// Mana 값 변경 통지
        /// </summary>
        // TODO 추후 Circle의 활용 방법 사양을 Fix할 예정 @Choi
        IObservable<int> OnManaValueChanged { get; }
        /// <summary>
        /// 잔여 턴수 종료 통지
        /// </summary>
        // TODO 不要かも？ @Choi
        IObservable<Unit> OnHandOver { get; }
        /// <summary>
        /// 클리어 목표 점수 변경 통지
        /// </summary>
        IObservable<int> OnGoalScoreChanged { get; }

        /// <summary>
        /// 잔여 패 버리기 수가 유효한지 결과 취득
        /// </summary>
        bool IsDiscardOver { get; }

        /// <summary>
        /// 현재 잔여 턴수 취득
        /// </summary>
        int CurrentHandCount { get; }
        /// <summary>
        /// 최대 턴수 취득
        /// </summary>
        int MaxHandCount { get; }
        /// <summary>
        /// 현재 잔여 패 버리기 수 취득
        /// </summary>
        int CurrentDiscardCount { get; }
        /// <summary>
        /// 골드 취득
        /// </summary>
        int CurrGold { get; }
        /// <summary>
        /// 목표 스코어값
        /// </summary>
        int GoalScore { get; }

        /// <summary>
        /// Circle 값 취득
        /// </summary>
        int CircleValue { get; }
        /// <summary>
        /// Mana 값 취득
        /// </summary>
        int ManaValue { get; }

        /// <summary>
        /// 턴수 감소
        /// </summary>
        /// <param name="val">인수를 넘겨주지 않는 한, 기본값 1</param>
        void DiscountHandCount( int val = 1 );
        /// <summary>
        /// 패 버리기 잔여 회수 감소
        /// </summary>
        /// <param name="val">감소할 값(선택한 카드 개수)</param>
        void DiscountDiscardCount( int val );
        /// <summary>
        /// 해당 스테이지의 최대 턴값 지정
        /// </summary>
        /// <param name="val">최대 턴값</param>
        void SetMaxHandCount( int val );
        /// <summary>
        /// 해당 스테이지에서의 최대 패 버리기 값
        /// </summary>
        /// <param name="val">최대 패 버리기 값</param>
        void SetMaxDiscardCount( int val );
        /// <summary>
        /// 해당 스테이지의 골드 값 지정
        /// </summary>
        /// <param name="val">골드 값</param>
        void SetGold( int val );
        /// <summary>
        /// 해당 스테이지의 목표 스코어 지정
        /// </summary>
        /// <param name="val">해당 스테이지의 목표 스코어</param>
        void SetGoalScore( int val );

        /// <summary>
        /// 해당 스테이지의 Circle 지정
        /// </summary>
        /// <param name="value">Circle 값</param>
        void SetCircleValue( int value );
        /// <summary>
        /// 해당 스테이지의 Mana 지정
        /// </summary>
        /// <param name="value">Mana값</param>
        void SetManaValue( int value );
    }
}
