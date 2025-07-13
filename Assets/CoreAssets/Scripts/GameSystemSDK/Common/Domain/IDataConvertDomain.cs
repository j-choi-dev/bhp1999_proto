using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Domain
{
    /// <summary>
    /// CSV �����͸� �ʿ���ϴ� ������ ������������ �Ľ��� �����ϴ� Domain Ŭ����
    /// @Auth Choi
    /// </summary>
    public interface IDataConvertDomain
    {
        /// <summary>
        /// Raw ���ڿ��� StageInfoData�� ����Ʈ�� ��ȯ
        /// </summary>
        /// <param name="value">raw ���ڿ�</param>
        /// <returns>StageInfoData�� ����Ʈ</returns>
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string value );
    }
}
