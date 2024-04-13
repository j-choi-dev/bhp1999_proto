using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystemSDK.Sound
{
    public class AudioClipList : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _list;

        public AudioClip GetAudioClip( string clipName ) => _list.FirstOrDefault( arg => arg.name.Equals( clipName ) );
    }
}
