using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Model
{
    /// <summary>
    /// �ܺ� ���� ���� Model ����
    /// @Auth Choi
    /// </summary>
    /// <remarks>�ϴ��� Server ������ �����ؼ�, Player Prefs�� ����, �ҷ����� ������� ������.</remarks>
    /// <remarks>Server �����Ͼ ������ �����ؾ� �� ���ɼ� ����.</remarks>
    public interface IExternalConnectModel
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
        /// <summary>
        /// �������� Ŭ���� ��, Ŭ������ �������� ID�� ����
        /// </summary>
        /// <param name="id">���� Ŭ������ �������� ID</param>
        void SetClearedStageInfo( string id );
        /// <summary>
        /// Play ���� ����
        /// </summary>
        /// <returns>UniTask �̺�Ʈ</returns>
        UniTask UpdateInfo();
        /// <summary>
        /// ������ ������ ī�� ���� ���
        /// </summary>
        /// <returns>ī�� ���� ID ����Ʈ</returns>
        UniTask<IReadOnlyList<string>> GetCardInfo();
        /// <summary>
        /// ī�� ���� � ���� �߰��� ī�� ID�� ���� ���� ī�带 �߰�
        /// </summary>
        /// <param name="id">�ű� ȹ���� ī�� ID</param>
        void AddCardInfo( string id );
        /// <summary>
        /// Stage ���� ����
        /// </summary>
        /// <param name="id">������ Stage ID</param>
        void EnterStage( string id );
    }
}
