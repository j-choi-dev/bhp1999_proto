using GameSystemSDK.BattleScene.Application;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Model
{
    public class BattleResourceModel : IBattleResourceModel
    {
        private IBattleResourceContext _battleResourceContext;

        public BattleResourceModel( IBattleResourceContext battleResourceContext )
        {
            _battleResourceContext = battleResourceContext;
        }

        public Sprite GetIconSprite( string id )
        {
            var operation = _battleResourceContext.GetIconSprite( id );
            if(operation.IsSuccess == false)
            {
                Debug.LogError( operation.ErrorMessage );
                return default;
            }
            return operation.Value;
        }

        public Sprite GetIllustSprite( string id )
        {
            var operation = _battleResourceContext.GetIllustSprite( id );
            if( operation.IsSuccess == false )
            {
                Debug.LogError( operation.ErrorMessage );
                return default;
            }
            return operation.Value;
        }

        public string GetTableRawData( string id )
        {
            var operation = _battleResourceContext.GetTableRawData( id );
            if( operation.IsSuccess == false )
            {
                Debug.LogError( operation.ErrorMessage );
                return default;
            }
            return operation.Value;
        }
    }
}
