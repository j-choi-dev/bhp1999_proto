using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.Common.Application
{
    /// <summary>
    /// Stage 정보를 Stage 정보 데이터 리스트로 변환하기 위해 Model과 Domain 연결
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
