using GameSystemSDK.BattleScene.Application;
using System;


namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// Battle Effect �̺�Ʈ Model ���� Ŭ����
    /// @Auth Choi
    /// </summary>
    public class BattleEffectModel : IBattleEffectModel
    {
        private IBattleEffectContext _battleEffectContext;

        public IObservable<string> OnSkillNameChanged => _battleEffectContext.OnSkillNameChanged;

        public IObservable<(int index, int score)> OnScoreInfoChanged => _battleEffectContext.OnScoreInfoChanged;

        public IObservable<bool> OnIsEffectProccess => _battleEffectContext.OnIsEffectProccess;

        public BattleEffectModel( IBattleEffectContext battleEffectContext )
        {
            _battleEffectContext = battleEffectContext;
        }
    }
}
