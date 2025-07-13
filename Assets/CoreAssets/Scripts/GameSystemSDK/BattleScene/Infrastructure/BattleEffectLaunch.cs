using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Sound;
using System;
using UniRx;
using UnityEngine;

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

        public BattleEffectLaunch( IGameSoundController gameSoundController ) // Refactoringª¹ªëª«ªâ @Choi
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
                    detail.HandCardList[i].Value :
                    $" + {detail.HandCardList[i].Value}";
                _onScoreInfoChanged.OnNext( (i,detail.HandCardList[i].Value) );
                await UniTask.Delay( 1500 );
            }
            await UniTask.Delay( Interval * 2 );
            _onTotalScoreChanged.OnNext( _totalScore );
            await UniTask.Delay( Interval * 2 );
            _onIsEffectProccess.OnNext( false );
        }
    }
}
