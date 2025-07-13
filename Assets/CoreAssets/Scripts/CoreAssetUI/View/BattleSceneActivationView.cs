using CoreAssetUI.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class BattleSceneActivationView : MonoBehaviour, IBattleSceneActivationView
    {
        [SerializeField] private List<GameObject> _targetList = null;
        public void SetActive( bool isActive )
        {
            for( int i = 0; i<_targetList.Count; i++ )
            {
                _targetList[i].gameObject.SetActive( false );
            }
        }
    }
}
