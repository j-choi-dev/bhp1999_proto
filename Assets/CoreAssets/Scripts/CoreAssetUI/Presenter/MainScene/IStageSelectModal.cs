using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// Stage Select Modal�� ���õ� Interface
    /// @Auth Choi
    /// </summary>
    public interface IStageSelectModal
    {
        /// <summary>
        /// �������� ���� ��ư Ŭ��
        /// </summary>
        IObservable<string> OnButtonClick { get; }
        /// <summary>
        /// ���� �̸� ����
        /// </summary>
        /// <param name="value">���� �̸�</param>
        void SetWorldName( string value );
        /// <summary>
        /// ���� �̸� ����
        /// </summary>
        /// <param name="value">���� �̸�</param>
        void SetAreaName( string value );
        /// <summary>
        /// ������ ����
        /// </summary>
        /// <param name="value"></param>
        void SetGuage( int value );
        /// <summary>
        /// �������� ���� ����Ʈ�� ����
        /// </summary>
        /// <param name="list">�������� �����͸� �Ľ��� ������ ����Ʈ</param>
        void SetStageInfoList( IReadOnlyList<IStageInfoData> list );
    }
}
