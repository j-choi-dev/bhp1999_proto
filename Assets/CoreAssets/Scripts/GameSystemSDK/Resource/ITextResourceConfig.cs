using GameSystemSDK.Common.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Resource.Domain
{
    public interface ITextResourceConfig
    {
        IReadOnlyList<TextAsset> TableList { get; }
        IResult<string> GetTableRawData( string id );
    }
}
