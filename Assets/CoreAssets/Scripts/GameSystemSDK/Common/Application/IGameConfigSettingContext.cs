using GameSystemSDK.Common.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Application
{
    public interface IGameConfigSettingContext
    {
        public IGameConfigDomain GameConfigDomain { get; }

        void SetFPS( int fps );
        void SetScreenOrientation( ScreenOrientation orientation );
        void SetResolution( int widht, int height, bool isFullscreen );
    }
}
