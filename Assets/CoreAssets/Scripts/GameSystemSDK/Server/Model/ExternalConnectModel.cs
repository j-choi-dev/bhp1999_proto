using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Application;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Model
{
    public class ExternalConnectModel : IExternalConnectModel
    {
        private IExternalConnectContext _externalConnectContext;

        public ExternalConnectModel( IExternalConnectContext externalConnectContext )
        {
            _externalConnectContext = externalConnectContext;
        }

        public IObservable<IPlayInfo> OnChanged => _externalConnectContext.OnChanged;

        public void AddCardInfo( string id )
        {
            _externalConnectContext.AddCardInfo(id);
        }

        public IReadOnlyList<string> GetCardInfo()
        {
            return _externalConnectContext.GetCardInfo();
        }

        public async UniTask<string> GetClaeredStageID()
        {
            return await _externalConnectContext.GetClaeredStageID();
        }

        public async UniTask<string> GetID()
        {
            return await _externalConnectContext.GetID();
        }

        public async UniTask<string> GetLogInTime()
        {
            return await _externalConnectContext.GetLogInTime();
        }

        public async UniTask Initialize()
        {
            await _externalConnectContext.Initialize();
        }

        public void SetClearedStageInfo( string id )
        {
            _externalConnectContext.SetClearedStageInfo( id ).Forget();
        }

        public async UniTask UpdateInfo()
        {
            await _externalConnectContext.UpdateInfo();
        }

        public void UpdateLogInTime()
        {
            _externalConnectContext.UpdateLogInTime();
        }

        public void EnterStage(string id)
        {
            _externalConnectContext.SetEnterStage( id );
        }

        public async UniTask<string> GetStageID()
        {
            return await _externalConnectContext.GetStageID();
        }
    }
}
