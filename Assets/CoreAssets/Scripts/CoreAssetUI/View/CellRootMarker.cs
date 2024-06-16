using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.View
{
    public interface ICellRootMarker
    {
        Transform SelectionTransform { get; }
        Transform NormalTransform { get; }
        bool IsAtatched { get; }
         ICellBase Item { get; }

         void SetItem( ICellBase item );
         void RemoveItem();
    }

    public class CellRootMarker : MonoBehaviour, ICellRootMarker
    {
        [SerializeField] private Transform _normalTransform = null;
        [SerializeField] private Transform _selectionTransform = null;
        private ICellBase _item = null;

        public Transform SelectionTransform => _selectionTransform;
        public Transform NormalTransform => _normalTransform;
        public bool IsAtatched => _item != null;
        public ICellBase Item => _item;


        public void SetItem( ICellBase item )
        {
            _item = item;
        }

        public void RemoveItem()
        {
            if( _item != null && _item.GameObject != null)
            {
                _item.GameObject.SetActive( false );
                Destroy( _item.GameObject );
            }
            _item = null;
        }
    }
}
