using UnityEngine;

namespace GameSystemSDK.Sound
{
    /// <summary>
    /// Game Sound ��Ʈ�� ��ũ��Ʈ
    /// @Auth Choi
    /// </summary>
    public interface IGameSoundController
    {
        /// <summary>
        /// Sound Effect ��� �÷���
        /// </summary>
        bool IsPlayingEffect { get; }
        /// <summary>
        /// BGM ��� �÷���
        /// </summary>
        bool IsPlayingBGM { get; }
        /// <summary>
        /// Sound Effect ���
        /// </summary>
        /// <param name="fileName">���ϸ�</param>
        void PlayEffect( string fileName );
        /// <summary>
        /// Sound Effect ���
        /// </summary>
        /// <param name="clip">AdioClip</param>
        void PlayEffect( AudioClip clip );
        /// <summary>
        /// BGM ���
        /// </summary>
        /// <param name="fileName">BGM ���ϸ�</param>
        void PlayBGM( string fileName );
        /// <summary>
        /// BGM ��� ����
        /// </summary>
        void StopBGM();
    }
}
