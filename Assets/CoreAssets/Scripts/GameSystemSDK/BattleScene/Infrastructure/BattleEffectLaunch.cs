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
        private readonly int Interval = 300;

        private IGameSoundController _gameSoundController;

        private Subject<string> _onSkillNameChanged = new Subject<string>();
        public IObservable<string> OnSkillNameChanged => _onSkillNameChanged;

        private Subject<(int index, int score)> _onScoreInfoChanged = new Subject<(int index, int score)>();
        public IObservable<(int index, int score)> OnScoreInfoChanged => _onScoreInfoChanged;


        private Subject<bool> _onIsEffectProccess = new Subject<bool>();
        public IObservable<bool> OnIsEffectProccess => _onIsEffectProccess;

        private int _totalScore = 0;
        private Subject<int> _onTotalScoreChanged = new Subject<int>();
        public IObservable<int> OnTotalScoreChanged => _onTotalScoreChanged;

        public BattleEffectLaunch( IGameSoundController gameSoundController ) // Refactoringするかも @Choi
        {
            _gameSoundController = gameSoundController;
        }

        public async UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect )
        {
            _onIsEffectProccess.OnNext( true );
            _onSkillNameChanged.OnNext( detail.Name );
            await UniTask.Delay( Interval * 2 );
            _gameSoundController.PlayEffect( effect );

            var scoreMsg = string.Empty;
            for(var i = 0; i< detail.HandCardList.Count; i++ )
            {
                scoreMsg += string.IsNullOrEmpty( scoreMsg ) ?
                    detail.HandCardList[i].PlayingCardInfo.Chip:
                    $" + {detail.HandCardList[i].PlayingCardInfo.Chip}";
                _onScoreInfoChanged.OnNext( (i,detail.HandCardList[i].PlayingCardInfo.Chip) );
                await UniTask.Delay( 1500 );
            }
            await UniTask.Delay( Interval * 2 );
            _onTotalScoreChanged.OnNext( _totalScore );
            await UniTask.Delay( Interval * 2 );
            _onIsEffectProccess.OnNext( false );
        }

        public void SelectHandProcess( IHandConditionInfo conditionInfo )
        {
            if( conditionInfo == null )
            {
                _onSkillNameChanged.OnNext($"판정: 없음" );
                return;
            }

            var strMsg = $"판정: {conditionInfo.Name} -> ({conditionInfo.AddPoint} X {conditionInfo.MultiplePoint})";
            _onSkillNameChanged.OnNext(strMsg);
        }
    }
}
