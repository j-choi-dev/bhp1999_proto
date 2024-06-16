using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

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
        IReadOnlyList<string> GetCardInfo();
        UniTask SetCardInfo( IReadOnlyList<IPlayingCardInfo> cardInfoList);
        UniTask AddCardInfo( string id );
        UniTask RemoveCardInfo( string id );
        UniTask ClearCardInfo();
        UniTask ChangeCardInfo( string id1, string id2 );
        UniTask AddHandLevel(int handsID, int addHandsLevel);
        UniTask<string> GetStageID();
        int GetHandLevel(int handsID);
    }
}
