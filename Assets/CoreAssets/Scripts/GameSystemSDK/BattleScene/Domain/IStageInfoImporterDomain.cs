using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Stage ���� ������ �ҷ����� Domain(IF)
    /// @Auth Choi
    /// </summary>
    /// <remarks>// TODO ���� ���� ���� ���������� ������ ��� IF ���� �߻� @Choi</remarks>
    public interface IStageInfoImporterDomain
    {
        IReadOnlyList<IStageInfoData> List { get; }

        UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadBattleInfo(string rawData);
        IStageInfoData GetBattleInfo( int index );
        IStageInfoData GetBattleInfo(string id);
    }
}
