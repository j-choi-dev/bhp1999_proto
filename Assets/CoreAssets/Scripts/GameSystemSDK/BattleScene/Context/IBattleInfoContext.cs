using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// Battle ���� ������ ���� Model�� Domain�� ����
    /// @Auth Choi
    /// </summary>
    public interface IBattleInfoContext
    {
        /// <summary>
        /// �������� ���� ������ ����Ʈ
        /// </summary>
        IReadOnlyList<IStageInfoData> StageInfoList { get; }
        /// <summary>
        /// �������� �� �ִ� �ϼ��� ������ ������ ����Ʈ
        /// </summary>
        IReadOnlyList<IHandInfoData> HandInfoDataList { get; }
        /// <summary>
        /// ���� ���� ������ ����ϱ� ���� Dictinary
        /// </summary>
        IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary { get; }

        /// <summary>
        /// �Ϲ� ī�� ���� ����Ʈ
        /// </summary>
        IReadOnlyList<IPlayingCardInfo> PlayingCardInfoList { get; }

        /// <summary>
        /// ī�� ���׷��̵� ����Ʈ
        /// </summary>
        IReadOnlyList<ICardUpgradeInfo> CardUpgradeList { get; }
        /// <summary>
        /// ī�� ����Ʈ Dictinary
        /// </summary>
        IReadOnlyDictionary<int, ICardEffectInfo> CardEffectDictionary { get; }

        /// <summary>
        /// �������� ���� ������ ����Ʈ�� �ε�
        /// </summary>
        /// <returns>�������� ���� ������ ����Ʈ</returns>
        /// <param name="rawData">Raw Text Data</param>
        UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadStageInfo( string rawData );

        /// <summary>
        /// Find Stage Info By Index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Stage Info Data</returns>
        IStageInfoData GetStageInfo( int index );

        /// <summary>
        /// Find Stage Info By ID(string)
        /// </summary>
        /// <param name="id">ID(string)</param>
        /// <returns>Stage Info Data</returns>
        IStageInfoData GetStageInfo( string id );

        /// <summary>
        /// ���� ������ ����Ʈ ó���� �����Ͽ� �ʱ�ȭ�� ����
        /// </summary>
        /// <param name="rawData">���� ���̺� ID</param>
        void InitHandDataList( string rawData );

        /// <summary>
        /// ���� ���� ����Ʈ ó���� �����Ͽ� �ʱ�ȭ�� ����
        /// </summary>
        /// <param name="rawData">���� ���� ���̺� Raw Data</param>
        void InitHandConditionDataList( string rawData );

        /// <summary>
        /// �÷��� ī�� ����Ʈ ���
        /// </summary>
        /// <param name="rawData">�÷��� ī�� ���̺�</param>
        void InitPlayingCardListStorageDomain( string rawData );

        /// <summary>
        /// ī�� ���׷��̵� ���� ���� ���
        /// </summary>
        /// <param name="rawData"></param>
        void InitCardUpgradeStorageDomain(string rawData);
        /// <summary>
        /// ������ ���� ī�� ȿ�� ���� ���
        /// </summary>
        /// <param name="rawData"></param>
        void InitCardEffectStorageDomain(string rawData);

        /// <summary>
        /// �÷��� ī�� �� ���� ����Ʈ
        /// </summary>
        /// <param name="DeckGroup">deck �׷� ID</param>
        /// <returns>�÷��� ī�� ���� ����Ʈ</returns>
        // TODO �����͸� �� int ��ſ� string Deck Group ID�� �ϴ°� ���� �� @Choi
        IReadOnlyList<IPlayingCardInfo> GetPlayingCardDeck( int DeckGroup );
    }
}
