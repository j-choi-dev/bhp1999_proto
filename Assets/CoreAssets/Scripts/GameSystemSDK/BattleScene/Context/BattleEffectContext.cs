using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// 배틀 중 연출 관련 Model과 Domain 연계
    /// @Auth Choi
    /// </summary>
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
    }
}
