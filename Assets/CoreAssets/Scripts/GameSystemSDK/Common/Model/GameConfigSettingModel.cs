using GameSystemSDK.Common.Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Model
{
    public interface IGameConfigSettingModel    
    {
        void SetGameSetting();
    }

    public class GameConfigSettingModel : IGameConfigSettingModel
    {
        private IGameConfigSettingContext _gameConfigSettingContext;

        public GameConfigSettingModel( IGameConfigSettingContext gameConfigSettingContext )
        {
            _gameConfigSettingContext = gameConfigSettingContext;
        }

        public void SetGameSetting()
        {
            var config = _gameConfigSettingContext.GameConfigDomain;
            _gameConfigSettingContext.SetFPS( config.FPS );
            _gameConfigSettingContext.SetResolution( config.Resolution.Widht, 
                config.Resolution.Height, 
                config.Resolution.IsFullScreen );
            _gameConfigSettingContext.SetScreenOrientation( config.Orientation );
        }
    }
}
