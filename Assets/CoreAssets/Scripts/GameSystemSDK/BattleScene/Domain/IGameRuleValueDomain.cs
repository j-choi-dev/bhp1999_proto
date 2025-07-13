using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// ���� ���࿡ �ʿ��� ��(Rule)�� ���õ� Domain
    /// @Auth Choi
    /// </summary>
    public interface IGameRuleValueDomain
    {
        /// <summary>
        /// ��(Hand) ���� ����
        /// </summary>
        IObservable<int> OnHandChanged { get; }
        /// <summary>
        /// �ܿ� �� ������(Discard) ���� ����
        /// </summary>
        IObservable<int> OnDiscardChanged { get; }
        /// <summary>
        /// Ŭ���� ����(Gold) ���� ����
        /// </summary>
        IObservable<int> OnGoldChanged { get; }
        /// <summary>
        /// Circle �� ���� ����
        /// </summary>
        // TODO ���� Circle�� Ȱ�� ��� ����� Fix�� ���� @Choi
        IObservable<int> OnCircleValueChanged { get; }
        /// <summary>
        /// Mana �� ���� ����
        /// </summary>
        // TODO ���� Circle�� Ȱ�� ��� ����� Fix�� ���� @Choi
        IObservable<int> OnManaValueChanged { get; }
        /// <summary>
        /// �ܿ� �ϼ� ���� ����
        /// </summary>
        // TODO ��驪��⣿ @Choi
        IObservable<Unit> OnHandOver { get; }
        /// <summary>
        /// Ŭ���� ��ǥ ���� ���� ����
        /// </summary>
        IObservable<int> OnGoalScoreChanged { get; }

        /// <summary>
        /// �ܿ� �� ������ ���� ��ȿ���� ��� ���
        /// </summary>
        bool IsDiscardOver { get; }

        /// <summary>
        /// ���� �ܿ� �ϼ� ���
        /// </summary>
        int CurrentHandCount { get; }
        /// <summary>
        /// �ִ� �ϼ� ���
        /// </summary>
        int MaxHandCount { get; }
        /// <summary>
        /// ���� �ܿ� �� ������ �� ���
        /// </summary>
        int CurrentDiscardCount { get; }
        /// <summary>
        /// ��� ���
        /// </summary>
        int CurrGold { get; }
        /// <summary>
        /// ��ǥ ���ھ
        /// </summary>
        int GoalScore { get; }

        /// <summary>
        /// Circle �� ���
        /// </summary>
        int CircleValue { get; }
        /// <summary>
        /// Mana �� ���
        /// </summary>
        int ManaValue { get; }

        /// <summary>
        /// �ϼ� ����
        /// </summary>
        /// <param name="val">�μ��� �Ѱ����� �ʴ� ��, �⺻�� 1</param>
        void DiscountHandCount( int val = 1 );
        /// <summary>
        /// �� ������ �ܿ� ȸ�� ����
        /// </summary>
        /// <param name="val">������ ��(������ ī�� ����)</param>
        void DiscountDiscardCount( int val );
        /// <summary>
        /// �ش� ���������� �ִ� �ϰ� ����
        /// </summary>
        /// <param name="val">�ִ� �ϰ�</param>
        void SetMaxHandCount( int val );
        /// <summary>
        /// �ش� �������������� �ִ� �� ������ ��
        /// </summary>
        /// <param name="val">�ִ� �� ������ ��</param>
        void SetMaxDiscardCount( int val );
        /// <summary>
        /// �ش� ���������� ��� �� ����
        /// </summary>
        /// <param name="val">��� ��</param>
        void SetGold( int val );
        /// <summary>
        /// �ش� ���������� ��ǥ ���ھ� ����
        /// </summary>
        /// <param name="val">�ش� ���������� ��ǥ ���ھ�</param>
        void SetGoalScore( int val );

        /// <summary>
        /// �ش� ���������� Circle ����
        /// </summary>
        /// <param name="value">Circle ��</param>
        void SetCircleValue( int value );
        /// <summary>
        /// �ش� ���������� Mana ����
        /// </summary>
        /// <param name="value">Mana��</param>
        void SetManaValue( int value );
    }
}
