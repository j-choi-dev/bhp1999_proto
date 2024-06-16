using GameSystemSDK.Common.Domain;
using GameSystemSDK.Resource.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    public class BattleResourceContext : IBattleResourceContext
    {
        private IBattleResourceConfig _battleResourceConfig;
        private ICardResourceConfig _cardResourceConfig;

        public BattleResourceContext( IBattleResourceConfig battleResourceConfig,
            ICardResourceConfig cardResourceConfig )
        {
            _battleResourceConfig = battleResourceConfig;
            _cardResourceConfig = cardResourceConfig;
        }

        public IReadOnlyList<Sprite> CardIllustList => _cardResourceConfig.CardIllustList;
        public IReadOnlyList<Sprite> CardValueTextList => _cardResourceConfig.CardValueTextList;
        public IReadOnlyList<Sprite> CardIconList => _cardResourceConfig.CardIconList;

        public IReadOnlyList<TextAsset> TableList => _battleResourceConfig.TableList;

        public IResult<Sprite> GetIconSprite( string id )
            => _cardResourceConfig.GetIconSprite( id );

        public IResult<Sprite> GetIllustSprite( string id )
            => _cardResourceConfig.GetIllustSprite( id );

        public IResult<string> GetTableRawData( string id )
            => _battleResourceConfig.GetTableRawData( id );

        public IResult<AudioClip> GetSoundEffectData( string id )
            => _battleResourceConfig.GetSoundEffectData( id );
    }
}
