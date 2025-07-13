using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.View
{
    public interface ICellRootMarker
    {
        Transform Transform { get; }
         bool IsAtatched { get; }
         ICellBase Item { get; }

         void SetItem( ICellBase item );
         void RemoveItem();
    }

    public class CellRootMarker : MonoBehaviour, ICellRootMarker
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private ICellBase _item = null;

        public Transform Transform => _transform;
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
