using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommonSystem.Util
{
    /// <summary>
    /// �� CSVReader��, CSV ������ Ž�� ��� �и�
    /// Original By Sang-ho Kim
    /// </summary>
    public static class CSVUtil
    {

        /// <summary>
        /// Ư�� ���� �÷��� �ش��ϴ� ������ ���
        /// </summary>
        /// <param name="rawData">��� CSV Raw Data</param>
        /// <param name="iRow">�� ��ȣ</param>
        /// <param name="strCol">�÷���</param>
        /// <returns>string Ÿ���� Raw-Data</returns>
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
        /// Ư�� �÷��� ��� �� �����͸� ���
        /// </summary>
        /// <param name="rawData">��� CSV Raw Data</param>
        /// <param name="columnName">�÷���</param>
        /// <returns>��� �÷��� ��� �� ������</returns>
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
