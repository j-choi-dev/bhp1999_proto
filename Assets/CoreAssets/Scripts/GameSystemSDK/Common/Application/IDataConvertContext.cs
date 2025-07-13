using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.Common.Application
{
    /// <summary>
    /// Stage 정보를 Stage 정보 데이터 리스트로 변환하기 위해 Model과 Domain 연결
    /// @Auth Choi
    /// </summary>
    public interface IDataConvertContext
    {
        /// <summary>
        /// Stage 정보를 Stage 정보 데이터 리스트로 변환
        /// </summary>
        /// <param name="rawData">CSV등 텍스트 기반으로 읽어들인 Raw Data</param>
        /// <returns>Stage 정보 데이터</returns>
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string rawData );
    }
}
