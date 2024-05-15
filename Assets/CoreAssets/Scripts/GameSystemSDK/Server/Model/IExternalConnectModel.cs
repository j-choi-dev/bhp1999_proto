using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Model
{
    public interface IExternalConnectModel
    {
        IObservable<IPlayInfo> OnChanged { get; }

        UniTask Initialize();
        UniTask<string> GetID();
        UniTask<string> GetClaeredStageID();
        void UpdateLogInTime();
        UniTask<string> GetLogInTime();
        void SetClearedStageInfo( string id );
        UniTask UpdateInfo();
        UniTask<IReadOnlyList<string>> GetCardInfo();
        void AddCardInfo( string id );
        void EnterStage( string id );
    }
}
