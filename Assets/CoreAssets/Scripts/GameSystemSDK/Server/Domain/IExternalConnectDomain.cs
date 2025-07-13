using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Domain
{
    /// <summary>
    /// �ܺ� ���� ���� Domain
    /// @Auth Choi
    /// </summary>
    /// <remarks>Server / PlayerPrefs �� User ������ �����ϰ� ó���ϴ� Infrastructure�� ���� �� Interface ����� ��</remarks>
    public interface IExternalConnectDomain
    {
        /// <summary>
        /// Play ������ ����� �� �߻��ϴ� �̺�Ʈ
        /// </summary>
        IObservable<IPlayInfo> OnChanged { get; }

        /// <summary>
        /// �ʱ�ȭ
        /// </summary>
        /// <returns>UniTask �̺�Ʈ</returns>
        UniTask Initialize();
        /// <summary>
        /// User ID ���
        /// </summary>
        /// <returns>User ID</returns>
        UniTask<string> GetID();
        /// <summary>
        /// ���� Ŭ������ Stage ID
        /// </summary>
        /// <returns>Stage ID</returns>
        UniTask<string> GetClaeredStageID();
        /// <summary>
        /// ���� �α��� �ð� ����
        /// </summary>
        void UpdateLogInTime();
        /// <summary>
        /// ���� �α��� �ð� ���
        /// </summary>
        /// <returns>���� �α��� �ð��� ���ڿ�</returns>
        UniTask<string> GetLogInTime();
        UniTask SetEnterStage( string id );
        /// <summary>
        /// �������� Ŭ���� ��, Ŭ������ �������� ID�� ����
        /// </summary>
        /// <param name="id">���� Ŭ������ �������� ID</param>
        UniTask SetClearedStageInfo( string id );
        /// <summary>
        /// Storage Update (Play ���� ����)
        /// </summary>
        /// <returns></returns>
        UniTask UpdateStorage();
        /// <summary>
        /// ������ ������ ī�� ���� ���
        /// </summary>
        /// <returns>ī�� ���� ID ����Ʈ</returns>
        UniTask<IReadOnlyList<string>> GetCardInfo();
        /// <summary>
        /// ī�� ���� � ���� �߰��� ī�� ID�� ���� ���� ī�带 �߰�
        /// </summary>
        /// <param name="id">�ű� ȹ���� ī�� ID</param>
        UniTask AddCardInfo( string id );
        /// <summary>
        /// ��� ī�带 ����
        /// </summary>
        /// <param name="id">������ ī���� ID</param>
        /// <returns>UniTask</returns>
        UniTask RemoveCardInfo( string id );
        /// <summary>
        /// ���� ī�� ������ ���� ����
        /// </summary>
        /// <returns>UniTask</returns>
        UniTask ClearCardInfo();
        /// <summary>
        /// Stage ID ���
        /// </summary>
        /// <returns>Stage ID</returns>
        UniTask<string> GetStageID();
    }
}
