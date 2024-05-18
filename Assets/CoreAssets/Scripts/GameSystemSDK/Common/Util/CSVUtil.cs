using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommonSystem.Util
{
    /// <summary>
    /// 구 CSVReader중, CSV 데이터 탐색 기능 분리
    /// Original By Sang-ho Kim
    /// </summary>
    public static class CSVUtil
    {

        /// <summary>
        /// 특정 행의 컬럼명에 해당하는 데이터 취득
        /// </summary>
        /// <param name="rawData">대상 CSV Raw Data</param>
        /// <param name="iRow">행 번호</param>
        /// <param name="strCol">컬럼명</param>
        /// <returns>string 타입의 Raw-Data</returns>
        public static string GetData( IReadOnlyList<Dictionary<string, string>> rawData, 
            int iRow, 
            string strCol )
        {
            var strValue = string.Empty;
            if( rawData != null && rawData.Any() )
            {
                rawData.ToList()[iRow].TryGetValue( strCol, out strValue );
            }

            return strValue;
        }

        /// <summary>
        /// 특정 컬럼의 모든 열 데이터를 취득
        /// </summary>
        /// <param name="rawData">대상 CSV Raw Data</param>
        /// <param name="columnName">컬럼명</param>
        /// <returns>헤당 컬럼의 모든 열 데이터</returns>
        public static IReadOnlyList<string> GetDataList( IReadOnlyCollection<Dictionary<string, string>> rawData, 
            string columnName )
        {
            var retVal = rawData.Select(dic => dic)
                .Where(arg => arg.TryGetValue( columnName, out string strValue ))
                .Select(arg => arg[columnName])
                .ToList();
            return retVal;
        }
    }
}
