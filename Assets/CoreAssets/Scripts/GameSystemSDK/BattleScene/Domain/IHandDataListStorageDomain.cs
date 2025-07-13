using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// ���� ���� ������ �ʱ�ȭ �� �����ϴ� Ŭ����
    /// @Auth Choi
    /// </summary>
    public interface IHandDataListStorageDomain
    {
        /// <summary>
        /// �ܺο��� ������ ���� ������ ����Ʈ
        /// </summary>
        IReadOnlyList<IHandInfoData> HandInfoDataList { get; }

        /// <summary>
        /// �ܺο��� ������ ���� ���� ����
        /// </summary>
        IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary { get; }

        /// <summary>
        /// ���� ������ ����Ʈ �ʱ�ȭ �� ����� ����.
        /// </summary>
        /// <param name="rawData">string type Raw Data</param>
        void InitHandDataList( IReadOnlyList<Dictionary<string, string>> rawData );

        /// <summary>
        /// ���� ���� ����Ʈ �ʱ�ȭ �� ����� ����.
        /// </summary>
        /// <param name="rawData">string type Raw Data</param>
        void InitHandConditionDataList( IReadOnlyList<Dictionary<string, string>> rawData );
    }
}
