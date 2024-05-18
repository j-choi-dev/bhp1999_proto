using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Application
{
    public interface IExternalConnectContext
    {
        IObservable<IPlayInfo> OnChanged { get; }

        UniTask Initialize();
        UniTask<string> GetID();
        UniTask<string> GetClaeredStageID();
        void UpdateLogInTime();
        UniTask<string> GetLogInTime();
        UniTask SetClearedStageInfo( string id );
        UniTask UpdateInfo();
        UniTask<IReadOnlyList<string>> GetCardInfo();
        UniTask AddCardInfo( string id );
        UniTask RemoveCardInfo( string id );
        UniTask ClearCardInfo();
        UniTask SetEnterStage( string id );
        UniTask<string> GetStageID();
    }
}
