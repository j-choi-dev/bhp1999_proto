using GameSystemSDK.Common.Domain;
using UnityEngine;

namespace GameSystemSDK.Common.Application
{
    public class GameConfigSettingContext : IGameConfigSettingContext
    {
        private IGameConfigSettingDomain _gameConfigSettingDomain;
        public IGameConfigDomain GameConfigDomain { get; private set; }

        public GameConfigSettingContext( IGameConfigSettingDomain gameConfigSettingDomain)
        {
            _gameConfigSettingDomain = gameConfigSettingDomain;
            GameConfigDomain = new GameConfigDomain();
        }

        public void SetFPS( int fps )
            => _gameConfigSettingDomain.SetFPS( fps );

        public void SetResolution( int widht, int height, bool isFullscreen )
            => _gameConfigSettingDomain.SetResolution( widht, height, isFullscreen );

        public void SetScreenOrientation( ScreenOrientation orientation )
            => _gameConfigSettingDomain.SetScreenOrientation( orientation );
    }
}
