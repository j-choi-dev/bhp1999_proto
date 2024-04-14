using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface IBattleInfoImporterDomain
    {
        IReadOnlyList<IBattleInfoData> List { get; }

        UniTask<IResult<IReadOnlyList<IBattleInfoData>>> LoadBattleInfo();
        IBattleInfoData GetBattleInfo( int index );
        IBattleInfoData GetBattleInfo(string id);
    }
}
