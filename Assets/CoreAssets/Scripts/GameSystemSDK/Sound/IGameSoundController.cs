using UnityEngine;

namespace GameSystemSDK.Sound
{
    public interface IGameSoundController
    {
        bool IsPlayingEffect { get; }
        bool IsPlayingBGM { get; }
        void PlayEffect( string fileName );
        void PlayEffect( AudioClip clip );
        void PlayBGM( string fileName );
        void StopBGM();
    }
}
