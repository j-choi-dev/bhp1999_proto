using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// �÷��� ī�忡 ���õ� �����͸� �����ϰ� ����
    /// @Auth Samdong
    /// </summary>
    public interface IPlayingCardListStorageDomain
    {
        /// <summary>
        /// �ܺο��� ������ �� ����Ʈ ����
        /// </summary>
        IReadOnlyList<IPlayingCardInfo> PlayingCardDeckList { get; }


        /// <summary>
        /// �÷��� ī�带 �а� ����
        /// </summary>
        void InitPlayingCardList(IReadOnlyList<Dictionary<string, string>> rawData);
    }
}