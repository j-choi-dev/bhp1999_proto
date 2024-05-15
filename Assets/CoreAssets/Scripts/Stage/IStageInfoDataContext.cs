using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.Stage.Application
{
    public interface IStageInfoDataContext
    {
        IObservable<IStageInfoData> OnCurrentStageChanged { get; }
        IStageInfoData CurrentStage { get; }
        IObservable<IReadOnlyList<IStageInfoData>> OnListChanged { get; }
        IReadOnlyList<IStageInfoData> List { get; }
        void SetStageInfoByTable( string rawData );
        IResult<IReadOnlyList<IStageInfoData>> CurrentUserStageInfoCheck( string id );
    }
}
