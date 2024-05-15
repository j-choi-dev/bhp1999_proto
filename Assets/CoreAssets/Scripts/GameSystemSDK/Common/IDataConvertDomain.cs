using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Domain
{
    public interface IDataConvertDomain
    {
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string value );
    }
}
