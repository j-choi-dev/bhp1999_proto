using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Domain
{
    public interface IGameConfigSettingDomain
    {
        void SetFPS( int fps );
        void SetScreenOrientation( ScreenOrientation orientation );
        void SetResolution( int widht, int height, bool isFullscreen );
    }
}
