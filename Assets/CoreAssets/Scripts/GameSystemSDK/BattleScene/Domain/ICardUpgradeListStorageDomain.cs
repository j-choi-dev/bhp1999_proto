using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// @Auth Choi
      /// ���� ���� ������ �ʱ�ȭ �� �����ϴ� Ŭ����
    /// </summary>
    public interface ICardUpgradeListStorageDomain
    {
        IReadOnlyList<ICardUpgradeInfo> CardUpgradeList { get; }

        IReadOnlyDictionary<int, ICardEffectInfo> CardEffectDictionary { get; }

        void InitCardUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );

        void InitCardEffectUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );
    }
}