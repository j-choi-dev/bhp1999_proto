using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameSystemSDK.Resource.Domain;

namespace GameSystemSDK.Resource.Infrastructure
{
    /// <summary>
    /// 게임 진행에 필요한 테이블 데이터 캐싱을 위한 Scriptable Object
    /// @Auth Choi
    /// </summary>
    /// <remarks>// TODO 알파로 넘어갈 경우, 반드시 폐기 대상! @Choi</remarks>
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
