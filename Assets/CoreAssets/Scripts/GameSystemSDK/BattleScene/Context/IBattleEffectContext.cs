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
    public interface IBattleEffectContext
    {
        /// <summary>
        /// 스킬 이름 변경 통지
        /// </summary>
        IObservable<string> OnSkillNameChanged { get; }
        /// <summary>
        /// 점수 정보 변경 통지
        /// </summary>
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        /// <summary>
        /// 연출 실행중인지 플래그 통지
        /// </summary>
        IObservable<bool> OnIsEffectProccess { get; }
        /// <summary>
        /// 연출 실행 Process
        /// </summary>
        /// <param name="detail">스코어 상세 정보</param>
        /// <param name="effect">Sound Effect Audio Clip</param>
        /// <returns></returns>
        UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect );
    }
}
