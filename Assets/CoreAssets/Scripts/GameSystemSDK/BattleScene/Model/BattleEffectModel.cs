using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// Battle Effect ÀÌº¥Æ® ¸ðµ¨
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
