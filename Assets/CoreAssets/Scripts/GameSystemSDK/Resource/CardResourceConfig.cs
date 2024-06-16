using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameSystemSDK.Resource.Domain;

namespace GameSystemSDK.Resource.Infrastructure
{
    [CreateAssetMenu( fileName = "NewCardResourceConfig", menuName = "GameSystemSDK/Resource=/CardResourceConfig" )]
    public class CardResourceConfig : ScriptableObject, ICardResourceConfig

    {
        [SerializeField] private List<Sprite> _cardIllustList = null;
        [SerializeField] private List<Sprite> _scores = null;
        [SerializeField] private List<Sprite> _cardIconList = null;

        public IReadOnlyList<Sprite> CardIllustList => _cardIllustList;
        public IReadOnlyList<Sprite> CardIconList => _cardIconList;
        public IReadOnlyList<Sprite> CardValueTextList => _scores;

        public IResult<Sprite> GetIllustSprite( string id )
        {
            var sprite = _cardIllustList.First(spr => spr.name.Equals(id));
            if( sprite == null )
            {
                return Result.Fail<Sprite>( $"CardResourceConfig.GetIllustSprite : {id} Not Exist" );
            }
            return Result.Success( sprite );
        }

        public IResult<Sprite> GetIconSprite( string id )
        {
            var sprite = _cardIconList.First(spr => spr.name.Equals(id));
            if(sprite == null)
            {
                return Result.Fail<Sprite>( $"CardResourceConfig.GetIconSprite : {id} Not Exist" );
            }
            return Result.Success(sprite);
        }

        public IResult<Sprite> GetValueTextSprite( string value )
        {
            var sprite = _scores.First(spr => spr.name.Equals(value));
            if( sprite == null )
            {
                return Result.Fail<Sprite>( $"CardResourceConfig.GetValueTextSprite : {value} Not Exist" );
            }
            return Result.Success( sprite );
        }
    }
}
