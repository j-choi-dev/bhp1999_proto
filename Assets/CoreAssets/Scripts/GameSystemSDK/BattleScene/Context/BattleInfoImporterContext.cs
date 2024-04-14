using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    public class BattleInfoImporterContext : IBattleInfoImporterContext
    {
        private IBattleInfoImporterDomain _battleInfoImporterDomain;

        public BattleInfoImporterContext( IBattleInfoImporterDomain battleInfoImporterDomain)
        {
            _battleInfoImporterDomain = battleInfoImporterDomain;
        }

        public IReadOnlyList<IBattleInfoData> List => _battleInfoImporterDomain.List;

        public IBattleInfoData GetBattleInfo( int index ) 
            => _battleInfoImporterDomain.GetBattleInfo( index );
        public IBattleInfoData GetBattleInfo( string id ) 
            => _battleInfoImporterDomain.GetBattleInfo( id );
        public UniTask<IResult<IReadOnlyList<IBattleInfoData>>> LoadBattleInfo()
            => _battleInfoImporterDomain.LoadBattleInfo();
    }
}
