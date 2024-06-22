using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Application
{
    public class ExternalConnectContext : IExternalConnectContext
    {
        private IExternalConnectDomain _externalConnectDomain;

        public ExternalConnectContext(IExternalConnectDomain externalConnectDomain)
        {
            _externalConnectDomain = externalConnectDomain;
        }

        public IObservable<IPlayInfo> OnChanged => _externalConnectDomain.OnChanged;

        public UniTask AddCardInfo(string id)
            => _externalConnectDomain.AddCardInfo(id);

        public UniTask ClearCardInfo()
            => _externalConnectDomain.ClearCardInfo();
        public UniTask ChangeCardInfo(string id1, string id2)
            => _externalConnectDomain.ChangeCardInfo(id1, id2);

        public IReadOnlyList<string> GetCardInfo()
            => _externalConnectDomain.GetCardInfo();

        public UniTask SetCardInfo(IReadOnlyList<IPlayingCardInfo> cardInfoList)
            => _externalConnectDomain.SetCardInfo(cardInfoList);

        public UniTask<string> GetClaeredStageID()
            => _externalConnectDomain.GetClaeredStageID();

        public UniTask<string> GetID()
            => _externalConnectDomain.GetID();

        public UniTask<string> GetLogInTime()
            => _externalConnectDomain.GetLogInTime();

        public UniTask Initialize()
            => _externalConnectDomain.Initialize();

        public UniTask RemoveCardInfo(string id)
            => _externalConnectDomain.RemoveCardInfo(id);

        public UniTask SetClearedStageInfo(string id)
            => _externalConnectDomain.SetClearedStageInfo(id);

        public UniTask UpdateInfo()
            => _externalConnectDomain.UpdateStorage();

        public void UpdateLogInTime()
            => _externalConnectDomain.UpdateLogInTime();

        public UniTask SetEnterStage(string id)
            => _externalConnectDomain.SetEnterStage(id);

        public UniTask<string> GetStageID()
            => _externalConnectDomain.GetStageID();

        public UniTask AddHandLevel(int handsID, int addHandsLevel)
            => _externalConnectDomain.AddHandLevel(handsID, addHandsLevel);

        public int GetHandLevel(int handsID)
            => _externalConnectDomain.GetHandLevel(handsID);
    }
}
