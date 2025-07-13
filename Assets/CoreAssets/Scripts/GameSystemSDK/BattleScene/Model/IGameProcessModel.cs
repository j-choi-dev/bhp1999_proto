using System.Collections.Generic;
using UniRx;
using System;
using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// ������ ������� �� ���� ���࿡ �ʿ��� ��ġ�� Model
    /// @Auth Choi
    /// </summary>
    public interface IGameProcessModel
    {
        /// <summary>
        /// �ܿ� �ڵ� ī��Ʈ ���� �̺�Ʈ
        /// </summary>
        IObservable<int> OnHandChanged { get; }

        /// <summary>
        /// �ܿ� ī�� ������ ī��Ʈ ���� �̺�Ʈ
        /// </summary>
        IObservable<int> OnDiscardChanged { get; }

        /// <summary>
        /// ���������� ��尪 ���� �̺�Ʈ
        /// </summary>
        IObservable<int> OnGoldChanged { get; }

        IObservable<int> OnGoalScoreChanged { get; }

        /// <summary>
        /// ���������� Circle�� ���� �̺�Ʈ
        /// </summary>
        IObservable<int> OnCircleValueChanged { get; }

        /// <summary>
        /// ���������� Mana�� ���� �̺�Ʈ
        /// </summary>
        IObservable<int> OnManaValueChanged { get; }

        /// <summary>
        /// �ڵ� ����(=���� ����) �̺�Ʈ
        /// </summary>
        IObservable<Unit> OnHandOver { get; }
        /// <summary>
        /// View�� ǥ���� �������� �̸� ���� �̺�Ʈ
        /// </summary>
        IObservable<string> OnStageNameChanged { get; }
        /// <summary>
        /// View�� ǥ���� �������� ����ȿ�� 1 ���� �̺�Ʈ
        /// </summary>
        IObservable<string> OnStageBuff1Change { get; }
        /// <summary>
        /// View�� ǥ���� �������� ����ȿ�� 2 ���� �̺�Ʈ
        /// </summary>
        IObservable<string> OnStageBuff2Change { get; }
        /// <summary>
        /// View�� ǥ���� �������� ����ȿ�� 3 ���� �̺�Ʈ
        /// </summary>
        IObservable<string> OnStageBuff3Change { get; }
        /// <summary>
        /// Hand ���� �� ���� ���� ���� �÷��׿� ���� �̺�Ʈ
        /// </summary>
        IObservable<bool> OnHandProcessRun { get; }
        /// <summary>
        /// ��������� �������� �˸��� �̺�Ʈ
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
        /// <returns>�񵿱� ó�� UniTask</returns>
        UniTask Initialize();

        /// <summary>
        /// �ڵ� ����
        /// </summary>
        /// <returns>�񵿱� ó�� UniTask</returns>
        UniTask RunHand();

        void DiscardProcess( string id );

        /// <summary>
        /// �ܿ� �ڵ� �� ����
        /// </summary>
        /// <param name="val">���� ������ ���� ���, Default�� 1</param>
        void DiscountHandCount( int val = 1 );

        /// <summary>
        /// ī�� ������ �� ����
        /// </summary>
        /// <param name="val">���� ������ ���� ���, Default�� 1</param>
        void DiscountDiscardCount( int val );

        /// <summary>
        /// ���������� ���� ������ �ڵ� �ִ밪 ����
        /// </summary>
        /// <param name="val">�ִ� �ڵ尪(��)</param>
        void SetMaxHandCount( int val );

        /// <summary>
        /// ���������� ���� ������ ī�� ������ �ִ밪 ����
        /// </summary>
        /// <param name="val">�ִ� ī�� ������ ȸ��</param>
        void SetMaxDiscardCount( int val );

        /// <summary>
        /// Gold�� ����
        /// </summary>
        /// <param name="val">Gold��</param>
        void SetGold( int val );

        void SetGoalScore( int val );

        /// <summary>
        /// Circle�� ����
        /// </summary>
        /// <param name="val">Circle��</param>
        void SetCircleValue( int value );

        /// <summary>
        /// Mana�� ����
        /// </summary>
        /// <param name="val">Mana��</param>
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
