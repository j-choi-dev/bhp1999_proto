using GameSystemSDK.Common.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Infrastructure
{
    public class GameConfigSettingInfrastructure : IGameConfigSettingDomain
    {
        public void SetFPS( int fps )
        {
            UnityEngine.Application.targetFrameRate = fps;
        }

        public void SetResolution( int widht, int height, bool isFullscreen )
        {
            Screen.SetResolution( widht, height, isFullscreen );
        }

        public void SetScreenOrientation( ScreenOrientation orientation )
        {
            Screen.orientation = orientation;
        }
    }
}
