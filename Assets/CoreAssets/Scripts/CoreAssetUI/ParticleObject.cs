using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI
{
    public class ParticleObject : MonoBehaviour
    {
        [SerializeField] List<ParticleSystem> _prticleList = null;

        public void Play()
        {
            for(int i = 0; i< _prticleList.Count; i++ )
            {
                _prticleList[i].Play();
            }
        }

        public void Stop()
        {
            for( int i = 0; i< _prticleList.Count; i++ )
            {
                _prticleList[i].Stop();
            }
        }
    }
}
