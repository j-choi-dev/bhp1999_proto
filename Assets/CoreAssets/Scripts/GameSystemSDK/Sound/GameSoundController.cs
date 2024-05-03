using UnityEngine;

namespace GameSystemSDK.Sound
{
    public class GameSoundController : MonoBehaviour, IGameSoundController
    {
        [SerializeField] private AudioSource _effectSource = null;
        [SerializeField] private AudioSource _bgmSource = null;
        [SerializeField] private AudioClipList _effectClipList = null;
        [SerializeField] private AudioClipList _bgmClipList = null;

        public bool IsPlayingEffect => _effectSource.isPlaying;

        public bool IsPlayingBGM => _bgmSource.isPlaying;

        private void Awake()
        {
            _effectSource.Stop();
            _bgmSource.Stop();
        }

        public void PlayEffect(string fileName)
        {
            var clip = _effectClipList.GetAudioClip( fileName );
            _effectSource.PlayOneShot( clip );
        }

        public void PlayEffect( AudioClip clip )
        {
            _effectSource.PlayOneShot( clip );
        }

        public void PlayBGM( string fileName )
        {
            if( _bgmSource.isPlaying == true )
            {
                _bgmSource.Stop();
            }
            var clip = _bgmClipList.GetAudioClip( fileName );
            _bgmSource.clip = clip;
            if(_bgmSource.loop == false)
            {
                _bgmSource.loop = true;
            }
            _bgmSource.Play();
        }

        public void StopBGM()
        {
            if( _bgmSource.isPlaying == true )
            {
                _bgmSource.Stop();
            }
            _bgmSource.clip = null;
        }
    }
}
