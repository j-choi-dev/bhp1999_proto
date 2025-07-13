using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using UnityEngine;
using GameSystemSDK.Resource.Domain;

namespace GameSystemSDK.Resource.Application
{
    public class LocalResourceFileLoadContext : ILocalResourceFileLoadContext
    {
        private ITextResourceConfig _textResourceConfig;
        public IReadOnlyList<TextAsset> TableList => _textResourceConfig.TableList;

        public LocalResourceFileLoadContext( ITextResourceConfig textResourceConfig)
        {
            _textResourceConfig = textResourceConfig;
        }

        public IResult<string> GetTableRawData( string id )
            => _textResourceConfig.GetTableRawData( id );
    }
}
