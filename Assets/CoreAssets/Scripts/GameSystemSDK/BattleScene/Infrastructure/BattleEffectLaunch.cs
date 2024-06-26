using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Sound;
using System;
using System.Net;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class BattleEffectLaunch : IBattleEffectLaunchDomain
    {
        private IGameSoundController _gameSoundController;

        private Subject<string> _onSkillNameChanged = new Subject<string>();
        public IObservable<string> OnSkillNameChanged => _onSkillNameChanged;

        private Subject<(int index, int score)> _onScoreInfoChanged = new Subject<(int index, int score)>();
        public IObservable<(int index, int score)> OnScoreInfoChanged => _onScoreInfoChanged;


        private Subject<bool> _onIsEffectProccess = new Subject<bool>();
        public IObservable<bool> OnIsEffectProccess => _onIsEffectProccess;

        public BattleEffectLaunch( IGameSoundController gameSoundController ) // Refactoringするかも @Choi
        {
            _gameSoundController = gameSoundController;
        }

        public async UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect )
        {
            //_onIsEffectProccess.OnNext( true );
            _onSkillNameChanged.OnNext( detail.GetScoreMsg() );
            await UniTask.Delay( 600 );
            _gameSoundController.PlayEffect( effect );
        }

        public void RunScoreNextEffectProcess(IDetailScoreInfo detail, int idx)
        {
            _onSkillNameChanged.OnNext( detail.GetScoreMsg() );
            _onScoreInfoChanged.OnNext((idx, detail.HandCardList[idx].PlayingCardInfo.Chip ));
        }

        public void RunScoreEndEffectProcess()
        {
            _onSkillNameChanged.OnNext("");
        }

        public void SelectHandProcess( IHandConditionInfo conditionInfo )
        {
            if ( conditionInfo == null )
            {
                _onSkillNameChanged.OnNext($"판정: 없음" );
                return;
            }

            var strMsg = $"판정: {conditionInfo.Name}:Lv. {conditionInfo.HandLevel} -> ({conditionInfo.AddPoint} X {conditionInfo.MultiplePoint})";
            _onSkillNameChanged.OnNext(strMsg);
        }
    }
}
