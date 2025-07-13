using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Stage.Model
{
    public interface IStageInfoDataModel
    {
        IObservable<IReadOnlyList<IStageInfoData>> OnCurrentAvaliableStageList { get; }
        IObservable<IStageInfoData> OnLatestStageChanged { get; }
        IStageInfoData CurrentSelectedStage { get; }
        IStageInfoData CurrentLatestStage { get; }
        IObservable<IReadOnlyList<IStageInfoData>> OnStageInfoDataListChanged { get; }
        UniTask Initialize();
        UniTask LoadNewPlayableStageInfoData();
        void SetCurrentSelectedStageID(string id);
    }
}
