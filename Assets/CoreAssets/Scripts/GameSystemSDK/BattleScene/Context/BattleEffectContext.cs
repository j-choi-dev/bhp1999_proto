using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    public class BattleEffectContext : IBattleEffectContext
    {
        private IBattleEffectLaunchDomain _battleEffectLaunchDomain;
        public IObservable<string> OnSkillNameChanged => _battleEffectLaunchDomain.OnSkillNameChanged;

        public IObservable<(int index, int score)> OnScoreInfoChanged => _battleEffectLaunchDomain.OnScoreInfoChanged;

        public IObservable<bool> OnIsEffectProccess => _battleEffectLaunchDomain.OnIsEffectProccess;

        public BattleEffectContext( IBattleEffectLaunchDomain battleEffectLaunchDomain )
        {
            _battleEffectLaunchDomain = battleEffectLaunchDomain;
        }

        public UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect )
            => _battleEffectLaunchDomain.RunScoreEffectProcess( detail, effect );

        public void RunScoreNextEffectProcess(IDetailScoreInfo detail, int idx)
            => _battleEffectLaunchDomain.RunScoreNextEffectProcess(detail, idx);

        public void RunScoreEndEffectProcess()
            => _battleEffectLaunchDomain.RunScoreEndEffectProcess();

        public void SelectHandProcess( IHandConditionInfo conditionInfo )
            => _battleEffectLaunchDomain.SelectHandProcess( conditionInfo );
    }
}
