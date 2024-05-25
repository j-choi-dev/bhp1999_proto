using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// @Auth Choi
      /// 족보 관련 데이터 초기화 및 보존하는 클래스
    /// </summary>
    public interface ICardUpgradeListStorageDomain
    {
        IReadOnlyDictionary<int, ICardUpgradeInfo> CardUpgradeDictionary { get; }

        void InitCardUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );

        void InitCardEffectUpgradeList( IReadOnlyList<Dictionary<string, string>> rawData );
    }
}
