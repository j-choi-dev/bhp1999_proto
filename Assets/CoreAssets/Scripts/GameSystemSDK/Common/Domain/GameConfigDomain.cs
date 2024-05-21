using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Domain
{
    public interface IGameConfigDomain
    {
        public ScreenOrientation Orientation { get; }
        public int FPS { get; }
        public ResolutionData Resolution { get; }
    }

    public struct ResolutionData
    {
        public int Widht { get; private set; }
        public int Height { get; private set; }
        public bool IsFullScreen { get; private set; }

        public ResolutionData( int widht, int height, bool isFullScreen )
        {
            Widht = widht;
            Height = height;
            IsFullScreen = isFullScreen;
        }
    }

    public class GameConfigDomain : IGameConfigDomain
    {
        public ScreenOrientation Orientation { get; private set; }

        public int FPS { get; private set; }

        public ResolutionData Resolution { get; private set; }

        public GameConfigDomain()
        {
            Orientation = ScreenOrientation.Portrait;
            FPS = 60;
            Resolution = new ResolutionData(1080, 1920, true);
        }
    }
}
