using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// ��Ʋ �� ���� ���� Model�� Domain ����
    /// @Auth Choi
    /// </summary>
    public interface IBattleEffectContext
    {
        /// <summary>
        /// ��ų �̸� ���� ����
        /// </summary>
        IObservable<string> OnSkillNameChanged { get; }
        /// <summary>
        /// ���� ���� ���� ����
        /// </summary>
        IObservable<(int index, int score)> OnScoreInfoChanged { get; }
        /// <summary>
        /// ���� ���������� �÷��� ����
        /// </summary>
        IObservable<bool> OnIsEffectProccess { get; }
        /// <summary>
        /// ���� ���� Process
        /// </summary>
        /// <param name="detail">���ھ� �� ����</param>
        /// <param name="effect">Sound Effect Audio Clip</param>
        /// <returns></returns>
        UniTask RunScoreEffectProcess( IDetailScoreInfo detail, AudioClip effect );
    }
}
