namespace GameSystem.Sound
{
    public interface IGameSoundController
    {
        bool IsPlayingEffect { get; }
        bool IsPlayingBGM { get; }
        void PlayEffect( string fileName );
        void PlayBGM( string fileName );
        void StopBGM();
    }
}
