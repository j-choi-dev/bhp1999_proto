using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Stage 관련 정보를 불러오는 Domain(IF)
    /// @Auth Choi
    /// </summary>
    /// <remarks>// TODO 추후 서버 정보 의존형으로 수정할 경우 IF 수정 발생 @Choi</remarks>
    public interface IStageInfoImporterDomain
    {
        IReadOnlyList<IStageInfoData> List { get; }

        UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadBattleInfo(string rawData);
        IStageInfoData GetBattleInfo( int index );
        IStageInfoData GetBattleInfo(string id);
    }
}
