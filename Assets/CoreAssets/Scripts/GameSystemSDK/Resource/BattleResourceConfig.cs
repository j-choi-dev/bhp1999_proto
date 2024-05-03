using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameSystemSDK.Resource.Domain;

namespace GameSystemSDK.Resource.Infrastructure
{
    [CreateAssetMenu( fileName = "NewBattleResourceConfig", menuName = "GameSystemSDK/Resource/BattleResourceConfig" )]
    public class BattleResourceConfig : ScriptableObject, IBattleResourceConfig
    {
        [SerializeField] private List<Sprite> _cardIllustList = null;
        [SerializeField] private List<Sprite> _cardIconList = null;
        [SerializeField] private List<TextAsset> _tableList = null;
        [SerializeField] private List<AudioClip> _soundEffect = null;

        public IReadOnlyList<Sprite> CardIllustList => _cardIllustList;

        public IReadOnlyList<Sprite> CardIconList => _cardIconList;
        public IReadOnlyList<TextAsset> TableList => _tableList;

        public IResult<Sprite> GetIllustSprite( string id )
        {
            var sprite = _cardIllustList.First(spr => spr.name.Equals(id));
            if( sprite == null )
            {
                return Result.Fail<Sprite>( $"BattleResourceConfig.GetIllustSprite : {id} Not Exist" );
            }
            return Result.Success( sprite );
        }

        public IResult<Sprite> GetIconSprite( string id )
        {
            var sprite = _cardIconList.First(spr => spr.name.Equals(id));
            if(sprite == null)
            {
                return Result.Fail<Sprite>( $"BattleResourceConfig.GetIconSprite : {id} Not Exist" );
            }
            return Result.Success(sprite);
        }

        public IResult<string> GetTableRawData( string id )
        {
            var data = _tableList.First(spr => spr.name.Equals(id));
            if( data == null )
            {
                return Result.Fail<string>( $"BattleResourceConfig.GetTable : {id} Not Exist" );
            }
            return Result.Success<string>( data.text );
        }

        public IResult<AudioClip> GetSoundEffectData( string id)
        {
            var data = _soundEffect.First(spr => spr.name.Equals(id));
            if( data == null )
            {
                return Result.Fail<AudioClip>( $"BattleResourceConfig.GetTable : {id} Not Exist" );
            }
            return Result.Success<AudioClip>( data );
        }
    }
}
