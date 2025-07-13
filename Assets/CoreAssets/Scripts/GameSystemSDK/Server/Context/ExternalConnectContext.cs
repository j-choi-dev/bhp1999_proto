using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Application
{
    /// <summary>
    /// Server등 외부와의 접속 및 통신시 관련된 Model과 Domain을 연결의 구현 클래스
    /// @Auth Choi
    /// </summary>
    public class ExternalConnectContext : IExternalConnectContext
    {
        private IExternalConnectDomain _externalConnectDomain;

        public ExternalConnectContext( IExternalConnectDomain externalConnectDomain )
        {
            _externalConnectDomain = externalConnectDomain;
        }

        public IObservable<IPlayInfo> OnChanged => _externalConnectDomain.OnChanged;

        public UniTask AddCardInfo( string id )
            => _externalConnectDomain.AddCardInfo(id);

        public UniTask ClearCardInfo()
            => _externalConnectDomain.ClearCardInfo();

        public UniTask<IReadOnlyList<string>> GetCardInfo()
            => _externalConnectDomain.GetCardInfo();

        public UniTask<string> GetClaeredStageID()
            => _externalConnectDomain.GetClaeredStageID();

        public UniTask<string> GetID()
            => _externalConnectDomain.GetID();

        public UniTask<string> GetLogInTime()
            => _externalConnectDomain.GetLogInTime();

        public UniTask Initialize()
            => _externalConnectDomain.Initialize();

        public UniTask RemoveCardInfo( string id )
            => _externalConnectDomain.RemoveCardInfo( id);

        public UniTask SetClearedStageInfo( string id )
            => _externalConnectDomain.SetClearedStageInfo( id );

        public UniTask UpdateInfo()
            => _externalConnectDomain.UpdateStorage();

        public void UpdateLogInTime()
            => _externalConnectDomain.UpdateLogInTime();

        public UniTask SetEnterStage( string id )
            => _externalConnectDomain.SetEnterStage( id );

        public UniTask<string> GetStageID()
            => _externalConnectDomain.GetStageID();
    }
}
