using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.Common.Application
{
    /// <summary>
    /// Stage ������ Stage ���� ������ ����Ʈ�� ��ȯ�ϱ� ���� Model�� Domain ����
    /// @Auth Choi
    /// </summary>
    public class DataConvertContext : IDataConvertContext
    {
        private IDataConvertDomain _dataConvertDomain;

        public DataConvertContext(IDataConvertDomain dataConvertDomain)
        {
            _dataConvertDomain = dataConvertDomain;
        }

        public IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string rawData )
        {
            return _dataConvertDomain.ConverToStageInfoDataList( rawData );
        }
    }
}
