using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

namespace CoreAssetUI.View
{
    public class ObservableButtonUGUI : ObservableButton
	{
		[SerializeField] private Button m_Button = null;

		public override IObservable<Unit> OnClick => m_Button.OnClickAsObservable();
		public override bool Interactable { get => m_Button.interactable; set => m_Button.interactable = value; }
		public override bool Enable { get => m_Button.enabled; set => m_Button.enabled = value; }

		private void Awake()
		{
		}

		public override string Name
		{
			get { return m_Button.name; }
			set { m_Button.name = value; }
		}

		public override Sprite Sprite
		{
			get { return m_Button.image.sprite; }
			set { m_Button.image.sprite = value; }
		}
    }
}
