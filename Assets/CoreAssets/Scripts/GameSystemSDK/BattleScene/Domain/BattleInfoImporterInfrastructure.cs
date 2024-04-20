using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Resource.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class BattleInfoImporterInfrastructure : IBattleInfoImporterDomain
    {
        private string _tableName = "StageDataMock";
        private IBattleResourceConfig _config;

        private List<IBattleInfoData> _list = new List<IBattleInfoData>();
        public IReadOnlyList<IBattleInfoData> List => _list;

        public BattleInfoImporterInfrastructure( IBattleResourceConfig config )
        {
            _config = config;
            _tableName = "StageDataMock";
        }

        public IBattleInfoData GetBattleInfo( string id )
        {
            return _list.First(arg => arg.ID.Equals(id));
        }

        public IBattleInfoData GetBattleInfo( int index )
        {
            return _list[index];
        }

        public async UniTask<IResult<IReadOnlyList<IBattleInfoData>>> LoadBattleInfo()
        {
            var textAsset = _config.GetTable(_tableName);
            //if( textAsset.IsSuccess != false )
            //{
            //    UnityEngine.Debug.LogError( $"BattleInfoImporterInfrastructure.LoadBattleInfo : {textAsset.ErrorMessage}" );
            //    return Result.Fail<IReadOnlyList<IBattleInfoData>>( $"BattleInfoImporterInfrastructure.LoadBattleInfo : {textAsset.ErrorMessage}" );
            //}
            var retVal = ConverToDataList(textAsset.Value);
            _list.AddRange( retVal );
            await UniTask.DelayFrame(1);
            return Result.Success( retVal );
        }

        private IReadOnlyList<IBattleInfoData> ConverToDataList(string value)
        {
            var rows = value.Split("\n");
            var list = new List<IBattleInfoData>();
            for(int i = 1; i < rows.Length; i++ )
            {
                var cols = rows[i].Split(",");
                var data = new BattleInfoData();
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
