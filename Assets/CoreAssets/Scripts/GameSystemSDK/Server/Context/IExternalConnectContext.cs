using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
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
        IReadOnlyList<string> GetCardInfo();
        UniTask SetCardInfo(IReadOnlyList<IPlayingCardInfo> cardInfoList);
        UniTask AddCardInfo( string id );
        UniTask RemoveCardInfo( string id );
        UniTask ClearCardInfo();
        UniTask ChangeCardInfo( string id1, string id2 );
        UniTask SetEnterStage( string id );
        UniTask<string> GetStageID();
        UniTask AddHandLevel(int handsID, int addHandsLevel);
        int GetHandLevel( int handsID );
    }
}
