using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI
{
    public class CardEffect : MonoBehaviour
    {
        [SerializeField] private List<ParticleObject> _particlePrefabList = null;

        public async UniTask Play()
        {
            for( int i = 0; i< _particlePrefabList.Count; i++ )
            {
                _particlePrefabList[i].gameObject.SetActive( true );
                _particlePrefabList[i].Play();
            }
            await UniTask.Delay( 1000 );

            for( int i = 0; i< _particlePrefabList.Count; i++ )
            {
                _particlePrefabList[i].Stop();
                _particlePrefabList[i].gameObject.SetActive( false );
            }
        }
    }
}
