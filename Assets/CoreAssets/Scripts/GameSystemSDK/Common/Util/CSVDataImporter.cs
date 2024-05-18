using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CommonSystem.Util
{
    /// <summary>
    /// 구 CSVReader중, CSV Import기능을 분리
    /// Original By Sang-ho Kim
    /// </summary>
    public static class CSVDataConverter
    {
        /// <summary>
        /// CSV Content(Raw Text Data) To Mapper
        /// </summary>
        /// <param name="rawData">CSV Content(Raw Text Data)</param>
        /// <returns>Mapper(Row and Column)</returns>
        public static IReadOnlyList<Dictionary<string, string>> ConvertProcess( string rawData )
        {
            var listData = new List<Dictionary<string, string>>();
            var header = new List<string>();

            var rows = rawData.Split("\n");
            for( var rowIdx = 0; rowIdx < rows.Length; rowIdx++ )
            {
                var replaceRow = rows[rowIdx].Replace("\r", "");

                if ( string.IsNullOrEmpty(replaceRow) )
                {
                    break;
                }
                var values = replaceRow.Split(',');
                if( rowIdx == 0 )
                {
                    header.AddRange( values );
                    continue;
                }
                var row = new Dictionary<string, string>();
                for( int colIdx = 0; colIdx < values.Length; colIdx++ )
                {
                    row[header[colIdx]] = values[colIdx];
                }
                listData.Add( row );
            }
            return listData;
        }
    }
}
