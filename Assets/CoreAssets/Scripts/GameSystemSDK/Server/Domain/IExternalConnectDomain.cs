using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Domain
{
    public interface IExternalConnectDomain
    {
        IObservable<IPlayInfo> OnChanged { get; }

        UniTask Initialize(); 
        UniTask<string> GetID();
        UniTask<string> GetClaeredStageID();
        void UpdateLogInTime();
        UniTask<string> GetLogInTime();
        UniTask SetEnterStage( string id );
        UniTask SetClearedStageInfo( string id );
        UniTask UpdateStorage();
        UniTask<IReadOnlyList<string>> GetCardInfo();
        UniTask AddCardInfo( string id );
        UniTask RemoveCardInfo( string id );
        UniTask ClearCardInfo();
        UniTask<string> GetStageID();
    }
}
