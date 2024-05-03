using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Resource.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class StageInfoImporterInfrastructure : IStageInfoImporterDomain
    {
        private List<IStageInfoData> _list = new List<IStageInfoData>();
        public IReadOnlyList<IStageInfoData> List => _list;

        public IStageInfoData GetBattleInfo( string id )
        {
            return _list.First(arg => arg.ID.Equals(id));
        }

        public IStageInfoData GetBattleInfo( int index )
        {
            return _list[index];
        }

        public async UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadBattleInfo(string rawData)
        {
            var retVal = ConverToDataList(rawData);
            _list.AddRange( retVal );
            await UniTask.DelayFrame(1);
            return Result.Success( retVal );
        }

        private IReadOnlyList<IStageInfoData> ConverToDataList(string value)
        {
            var rows = value.Split("\n");
            var list = new List<IStageInfoData>();
            for(int i = 1; i < rows.Length; i++ )
            {
                var cols = rows[i].Split(",");
                var data = new StageInfoData();
                data.SetID( cols[0] );
                data.SetMaxHandCount( int.Parse( cols[1] ) );
                data.SetMaxDiscardCount( int.Parse( cols[2] ) );
                data.SetGoldValue( int.Parse( cols[3] ) );
                data.SetStageName( cols[4] );
                data.SetStageBuff1( cols[5] );
                data.SetStageBuff2( cols[6] );
                data.SetStageBuff3( cols[7] );
                list.Add( data );
            }
            return list;
        }
    }
}
