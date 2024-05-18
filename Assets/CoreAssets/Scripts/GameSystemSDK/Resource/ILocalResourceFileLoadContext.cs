using GameSystemSDK.Common.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Resource.Application
{
    public interface ILocalResourceFileLoadContext
    {
        IReadOnlyList<TextAsset> TableList { get; }
        IResult<string> GetTableRawData( string id );
    }
}