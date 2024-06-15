using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public interface ISelectedCardCell
    {
        Transform SelectionTransform { get; }
        Transform NormalTransform { get; }
        Image Image { get; }
        string ID { get; }
        int Score { get; }

        void SetItem( string id, Sprite sprite, int score );
    }

    public class SelectedCardCell : MonoBehaviour, ISelectedCardCell
    {
        [SerializeField] private Transform _normalTransform = null;
        [SerializeField] private Transform _selectionTransform = null;
        [SerializeField] private Image _image = null;

        public Transform SelectionTransform => _selectionTransform;
        public Transform NormalTransform => _normalTransform;

        public Image Image => _image;

        public string ID { get; private set; }

        public int Score { get; private set; }

        public void SetItem( string id, Sprite sprite, int score )
        {
            ID = id;
            Image.sprite = sprite;
            Score = score;
        }
    }
}
