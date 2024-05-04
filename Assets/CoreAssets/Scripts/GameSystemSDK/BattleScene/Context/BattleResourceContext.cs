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

        public BattleResourceContext( IBattleResourceConfig battleResourceConfig )
        {
            _battleResourceConfig = battleResourceConfig;
        }

        public IReadOnlyList<Sprite> CardIllustList => _battleResourceConfig.CardIllustList;

        public IReadOnlyList<Sprite> CardIconList => _battleResourceConfig.CardIconList;

        public IReadOnlyList<TextAsset> TableList => _battleResourceConfig.TableList;

        public IResult<Sprite> GetIconSprite( string id )
            => _battleResourceConfig.GetIconSprite( id );

        public IResult<Sprite> GetIllustSprite( string id )
            => _battleResourceConfig.GetIllustSprite( id );

        public IResult<string> GetTableRawData( string id )
            => _battleResourceConfig.GetTableRawData( id );

        public IResult<AudioClip> GetSoundEffectData( string id )
            => _battleResourceConfig.GetSoundEffectData( id );
    }
}
