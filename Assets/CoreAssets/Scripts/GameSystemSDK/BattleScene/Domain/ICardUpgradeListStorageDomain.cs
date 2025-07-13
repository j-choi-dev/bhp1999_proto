using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// ���� ���� ������ �ʱ�ȭ �� �����ϴ� Ŭ����
    /// @Auth Choi
    /// </summary>
    public interface ICardUpgradeListStorageDomain
    {
        IReadOnlyList<ICardUpgradeInfo> CardUpgradeList { get; }

        IReadOnlyDictionary<int, ICardEffectInfo> CardEffectDictionary { get; }

        void InitCardUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );

        void InitCardEffectUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );
    }
}
