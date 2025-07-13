using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 족보 관련 데이터 초기화 및 보존하는 클래스
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
