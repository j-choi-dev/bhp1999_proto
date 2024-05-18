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
        IObservable<IStageInfoData> OnLatestStageChanged { get; }
        IStageInfoData CurrentLatestStage { get; }
        IObservable<IReadOnlyList<IStageInfoData>> OnListChanged { get; }
        IReadOnlyList<IStageInfoData> List { get; }
        void SetStageInfoByTable( string rawData );
        IResult<IReadOnlyList<IStageInfoData>> CheckCurrentStageInfo( string id );
        IResult<IStageInfoData> GetLatestPlayableStage();
    }
}
