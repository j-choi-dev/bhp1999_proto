using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Resource.Domain
{
    public interface IBattleResourceConfig
    {
        IReadOnlyList<Sprite> CardIllustList { get; }
        IReadOnlyList<Sprite> CardIconList { get; }
        IResult<Sprite> GetIllustSprite( string id );
        IResult<Sprite> GetIconSprite( string id );
    }
}
