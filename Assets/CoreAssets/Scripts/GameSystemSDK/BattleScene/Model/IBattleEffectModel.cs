using System;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// Battle Effect �̺�Ʈ Model
    /// @Auth Choi
    /// </summary>
    public interface IBattleEffectModel
    {
        IObservable<string> OnSkillNameChanged { get; }
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        IObservable<bool> OnIsEffectProccess { get; }
    }
}
