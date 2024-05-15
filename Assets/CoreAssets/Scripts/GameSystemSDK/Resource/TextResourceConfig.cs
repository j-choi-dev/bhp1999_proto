using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameSystemSDK.Resource.Domain;

namespace GameSystemSDK.Resource.Infrastructure
{
    [CreateAssetMenu( fileName = "NewTextResourceConfig", menuName = "GameSystemSDK/Resource/TextResourceConfig" )]
    public class TextResourceConfig : ScriptableObject, ITextResourceConfig
    {
        [SerializeField] private List<TextAsset> _tableList = null;
        public IReadOnlyList<TextAsset> TableList => _tableList;

        public IResult<string> GetTableRawData( string id )
        {
            var data = _tableList.First(spr => spr.name.Equals(id));
            if( data == null )
            {
                return Result.Fail<string>( $"TextResourceConfig.GetTable : {id} Not Exist" );
            }
            return Result.Success<string>( data.text );
        }
    }
}
