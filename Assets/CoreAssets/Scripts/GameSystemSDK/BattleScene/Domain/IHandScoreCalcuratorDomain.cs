using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Poker ���� ��� ��ũ��Ʈ
    /// </summary>
    /// @Auth Samdong
    public interface IHandScoreCalcuratorDomain
    {
        public IObservable<IDetailScoreInfo> OnDetailScoreInfo { get; }

        /// <summary>
        /// Get Max Score
        /// </summary>
        /// <param name="cardList">�ִ� 5�� ������ ���� ī�� ����Ʈ</param>
        /// <returns></returns>
        /// <remarks>�̰ɷ� ���� ã���ݴϴ�. to �翬��</remarks>
        (int id, IReadOnlyList<IBattleCard>) GetMaxPokerScore( IReadOnlyList<IHandInfoData> handDataList,
            IReadOnlyList<IBattleCard> cardList );

        /// <summary>
        /// ����(�ڵ�) ���꿡 �ʿ��� ������ Ž��
        /// </summary>
        /// <param name="handDataList">���� ������ ����Ʈ</param>
        /// <param name="id">���� ���� ID</param>
        /// <returns>���� ���� ������</returns>
        IHandConditionInfo GetPokerHandsInfoByID( IReadOnlyList<IHandInfoData> handDataList, int id );


        /// <summary>
        /// ���� ���ھ�� �� ������ ��ȯ
        /// </summary>
        /// <param name="cardList">���� �Ͽ��� ���õ� ī�� ����Ʈ</param>
        /// <param name="condition">���� ���� ���� ������</param>
        /// <returns>���� ���ھ�� �� ����</returns>
        IDetailScoreInfo GetScoreData( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo condition );
    }
}
