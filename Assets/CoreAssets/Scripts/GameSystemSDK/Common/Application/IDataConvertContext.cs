using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.Common.Application
{
    /// <summary>
    /// Stage ������ Stage ���� ������ ����Ʈ�� ��ȯ�ϱ� ���� Model�� Domain ����
    /// @Auth Choi
    /// </summary>
    public interface IDataConvertContext
    {
        /// <summary>
        /// Stage ������ Stage ���� ������ ����Ʈ�� ��ȯ
        /// </summary>
        /// <param name="rawData">CSV�� �ؽ�Ʈ ������� �о���� Raw Data</param>
        /// <returns>Stage ���� ������</returns>
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string rawData );
    }
}
