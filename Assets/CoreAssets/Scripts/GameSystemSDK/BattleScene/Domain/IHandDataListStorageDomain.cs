using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// @Auth Choi
      /// 족보 관련 데이터 초기화 및 보존하는 클래스
    /// </summary>
    public interface IHandDataListStorageDomain
    {
        /// <summary>
        ///  외부에서 참조할 족보 데이터 리스트
        /// </summary>
        IReadOnlyList<IHandInfoData> HandInfoDataList { get; }

        /// <summary>
            /// 외부에서 참조할 족보 조건 맵퍼
        /// </summary>
        IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary { get; }

        /// <summary>
            /// 족보 데이터 리스트 초기화 후 멤버에 저장.
        /// </summary>
        /// <param name="rawData">string type Raw Data</param>
        void InitHandDataList( IReadOnlyList<Dictionary<string, string>> rawData );

        /// <summary>
            /// 족보 조건 리스트 초기화 후 멤버에 저장.
        /// </summary>
        /// <param name="rawData">string type Raw Data</param>
        void InitHandConditionDataList( IReadOnlyList<Dictionary<string, string>> rawData );

        void InitHandLevelDataList(IReadOnlyList<Dictionary<string, string>> rawData);
    }
}
