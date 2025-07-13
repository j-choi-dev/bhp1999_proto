namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// �������� ���� ������
    /// @Auth Choi
    /// </summary>
    /// <remarks>CSV ������ ���� �� ���� Interface ���� �ʿ�</remarks>
    public interface IStageInfoData
    {
        /// <summary>
        /// ���� ������ ID
        /// </summary>
        string ID { get; }
        /// <summary>
        /// World ID
        /// </summary>
        string WorldID { get; }
        /// <summary>
        /// ���� ID
        /// </summary>
        string AreaID { get; }
        /// <summary>
        /// ���� ���� Stage ID
        /// </summary>
        string StageID { get; }

        /// <summary>
        /// World �̸�
        /// </summary>
        string WorldName { get; }
        /// <summary>
        /// ���� �̸�
        /// </summary>
        string AreaName { get; }
        /// <summary>
        /// Stage �̸�
        /// </summary>
        string StageName { get; }

        /// <summary>
        /// Boss Stage Flag
        /// </summary>
        bool IsBossStage { get; }

        /// <summary>
        /// �ش� �������������� �ִ� ��(hand)��
        /// </summary>
        int MaxHandCount { get; }
        /// <summary>
        /// �ش� �������������� �ִ� �� ������(Discard ��)
        /// </summary>
        int MaxDiscardCount { get; }
        /// <summary>
        /// �ش� ������������ ȹ�� ������ ���
        /// </summary>
        int GoldValue { get; }
        /// <summary>
        /// �ش� ���������� Ŭ�����ϱ� ���� ��ǥ ����
        /// </summary>
        int GoalScore { get; }

        /// <summary>
        /// Ŭ������ �������� ����
        /// </summary>
        bool IsClear { get; }

        /// <summary>
        /// ���� ID ����
        /// </summary>
        /// <param name="val">ID</param>
        public void SetID( string val );
        /// <summary>
        /// World ID ����
        /// </summary>
        /// <param name="val">World ID</param>
        public void SetWorldID( string val );
        /// <summary>
        /// ���� ID ����
        /// </summary>
        /// <param name="val">���� ID</param>
        public void SetAreaID( string val );
        /// <summary>
        /// �������� ID ����
        /// </summary>
        /// <param name="val"></param>
        public void SetStageID( string val );
        /// <summary>
        /// ���� �̸� ����
        /// </summary>
        /// <param name="val">�����</param>
        public void SetWorldName( string val );
        /// <summary>
        /// ������ ����
        /// </summary>
        /// <param name="val">������</param>
        public void SetAreaName( string val );
        /// <summary>
        /// �������� �̸� ����
        /// </summary>
        /// <param name="val">�������� �̸�</param>
        public void SetStageName( string val );

        /// <summary>
        /// ���� �������� �÷��� ����
        /// </summary>
        /// <param name="isVal">Boss �������� ����</param>
        public void SetIsBossStage( bool isVal );

        /// <summary>
        /// �ִ� ��(Hand)�� ����
        /// </summary>
        /// <param name="val">�ִ� ��(Hand ��)</param>
        public void SetMaxHandCount( int val );
        /// <summary>
        /// �ִ� �� ������(Discard)�� ����
        /// </summary>
        /// <param name="val"></param>
        public void SetMaxDiscardCount( int val );
        /// <summary>
        /// Ŭ����� ȹ�� ������ ��尪 ����
        /// </summary>
        /// <param name="val">��� ��</param>
        public void SetGoldValue( int val );
        /// <summary>
        /// Ŭ��� �ʿ��� ���ھ ����
        /// </summary>
        /// <param name="val">Ŭ��� �ʿ��� �ּ� ���ھ</param>
        public void SetGoalScore( int val );

        /// <summary>
        /// Ŭ���� ���� �÷��� ����
        /// </summary>
        /// <param name="isVal">Ŭ���� ����</param>
        public void SetIsClear( bool isVal );
    }
}
