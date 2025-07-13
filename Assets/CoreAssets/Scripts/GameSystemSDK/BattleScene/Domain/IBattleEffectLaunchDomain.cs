using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Effect ���� ���� Interface
    /// @Auth Choi
    /// </summary>
    public interface IBattleEffectLaunchDomain
    {
        IObservable<string> OnSkillNameChanged { get; }
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        IObservable<bool> OnIsEffectProccess { get; }
        UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect );
    }
}
