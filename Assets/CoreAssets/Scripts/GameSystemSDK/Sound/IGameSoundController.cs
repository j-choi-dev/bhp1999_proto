using UnityEngine;

namespace GameSystemSDK.Sound
{
    /// <summary>
    /// Game Sound 컨트롤 스크립트
    /// @Auth Choi
    /// </summary>
    public interface IGameSoundController
    {
        /// <summary>
        /// Sound Effect 재생 플래그
        /// </summary>
        bool IsPlayingEffect { get; }
        /// <summary>
        /// BGM 재생 플래그
        /// </summary>
        bool IsPlayingBGM { get; }
        /// <summary>
        /// Sound Effect 재생
        /// </summary>
        /// <param name="fileName">파일명</param>
        void PlayEffect( string fileName );
        /// <summary>
        /// Sound Effect 재생
        /// </summary>
        /// <param name="clip">AdioClip</param>
        void PlayEffect( AudioClip clip );
        /// <summary>
        /// BGM 재생
        /// </summary>
        /// <param name="fileName">BGM 파일명</param>
        void PlayBGM( string fileName );
        /// <summary>
        /// BGM 재생 중지
        /// </summary>
        void StopBGM();
    }
}
