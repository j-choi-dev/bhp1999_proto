﻿using UnityEngine;
using System;
using UniRx;

namespace CoreAssetUI.View
{
	public abstract class ObservableButton : MonoBehaviour
	{
		public abstract string Name { get; set; }
		public abstract Sprite Sprite { get; set; }
		public abstract IObservable<Unit> OnClick { get; }
		public abstract bool Interactable { get; set; }
		public abstract bool Enable { get; set; }
	}
}
