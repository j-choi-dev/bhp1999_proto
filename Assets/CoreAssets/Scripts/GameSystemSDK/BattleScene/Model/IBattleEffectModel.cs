using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// Battle Effect ÀÌº¥Æ® ¸ðµ¨
    /// </summary>
    public interface IBattleEffectModel
    {
        IObservable<string> OnSkillNameChanged { get; }
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        IObservable<bool> OnIsEffectProccess { get; }
    }
}
