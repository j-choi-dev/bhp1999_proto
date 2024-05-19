using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.Common.Application
{
    public interface IDataConvertContext
    {
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string rawData );
    }
}
