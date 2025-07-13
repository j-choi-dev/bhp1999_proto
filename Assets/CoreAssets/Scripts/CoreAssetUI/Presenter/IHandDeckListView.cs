using System;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// Drage°¡ °¡´ÉÇÑ µ¦ ¸®½ºÆ® ºä
    /// @Auth Choi
    /// </summary>
    public interface IHandDeckListView : IListView
    {
        IObservable<(string id, Vector2 pos)> OnDragStarted { get; }
        IObservable<(string id, Vector2 pos)> OnDragEnd { get; }
    }
}
