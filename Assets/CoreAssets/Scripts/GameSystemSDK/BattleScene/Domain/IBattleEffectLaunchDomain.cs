using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Effect 연출 관련 Domain Interface
    /// </summary>
    public interface IBattleEffectLaunchDomain
    {
        IObservable<string> OnSkillNameChanged { get; }
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        IObservable<bool> OnIsEffectProccess { get; }
        UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect );
        void SelectHandProcess(IHandConditionInfo conditionInfo);
    }
}
