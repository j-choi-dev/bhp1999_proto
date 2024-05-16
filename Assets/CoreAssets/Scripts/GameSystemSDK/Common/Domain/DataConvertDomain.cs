using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;


namespace GameSystemSDK.Common.Domain
{
    public class DataConvertDomain : IDataConvertDomain
    {
        public IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string rawData )
        {
            // TODO CSVUtil.Parse & Key Value´Â ValueDomainÀ¸·Î »¬ °Í @Choi
            var rows = rawData.Split("\n");
            var list = new List<IStageInfoData>();
            for( int i = 1; i < rows.Length; i++ )
            {
                var cols = rows[i].Split(",");
                var data = new StageInfoData();
                data.SetID( cols[0] );
                data.SetWorldID( cols[1] );
                data.SetAreaID( cols[2] );
                data.SetStageID( cols[3] );
                data.SetWorldName( cols[4] );
                data.SetAreaName( cols[5] );
                data.SetAreaName( cols[6] );
                var isBossStage = int.Parse( cols[7] ) == 1;
                data.SetIsBossStage( isBossStage );
                data.SetMaxHandCount( int.Parse( cols[8] ) );
                data.SetMaxDiscardCount( int.Parse( cols[9] ) );
                data.SetGoldValue( int.Parse( cols[10] ) );
                data.SetGoalScore( int.Parse( cols[11] ) );
                list.Add( data );
            }
            return list;
        }
    }
}
