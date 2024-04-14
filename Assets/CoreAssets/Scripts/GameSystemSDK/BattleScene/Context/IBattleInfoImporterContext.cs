using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public interface IBattleInfoImporterContext
    {
        IReadOnlyList<IBattleInfoData> List { get; }
        UniTask<IResult<IReadOnlyList<IBattleInfoData>>> LoadBattleInfo();
        IBattleInfoData GetBattleInfo( int index );
        IBattleInfoData GetBattleInfo( string id );
    }
}
