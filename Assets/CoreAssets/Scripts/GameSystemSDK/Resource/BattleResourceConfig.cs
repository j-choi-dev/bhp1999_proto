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
        [SerializeField] private List<TextAsset> _tableList = null;
        [SerializeField] private List<AudioClip> _soundEffect = null;

        public IReadOnlyList<TextAsset> TableList => _tableList;
        public IReadOnlyList<AudioClip> SoundEffectList => _soundEffect;

        public IResult<string> GetTableRawData( string id )
        {
            Debug.Log( id );
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
