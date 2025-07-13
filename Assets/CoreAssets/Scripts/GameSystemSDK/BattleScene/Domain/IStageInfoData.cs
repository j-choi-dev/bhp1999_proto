namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 스테이지 정보 데이터
    /// @Auth Choi
    /// </summary>
    /// <remarks>CSV 데이터 변경 시 필히 Interface 수정 필요</remarks>
    public interface IStageInfoData
    {
        /// <summary>
        /// 고유 데이터 ID
        /// </summary>
        string ID { get; }
        /// <summary>
        /// World ID
        /// </summary>
        string WorldID { get; }
        /// <summary>
        /// 지역 ID
        /// </summary>
        string AreaID { get; }
        /// <summary>
        /// 지역 내의 Stage ID
        /// </summary>
        string StageID { get; }

        /// <summary>
        /// World 이름
        /// </summary>
        string WorldName { get; }
        /// <summary>
        /// 지역 이름
        /// </summary>
        string AreaName { get; }
        /// <summary>
        /// Stage 이름
        /// </summary>
        string StageName { get; }

        /// <summary>
        /// Boss Stage Flag
        /// </summary>
        bool IsBossStage { get; }

        /// <summary>
        /// 해당 스테이지에서의 최대 턴(hand)수
        /// </summary>
        int MaxHandCount { get; }
        /// <summary>
        /// 해당 스테이지에서의 최대 패 버리기(Discard 수)
        /// </summary>
        int MaxDiscardCount { get; }
        /// <summary>
        /// 해당 스테이지에서 획득 가능한 골드
        /// </summary>
        int GoldValue { get; }
        /// <summary>
        /// 해당 스테이지를 클리어하기 위한 목표 점수
        /// </summary>
        int GoalScore { get; }

        /// <summary>
        /// 클리어한 스테이지 여부
        /// </summary>
        bool IsClear { get; }

        /// <summary>
        /// 고유 ID 지정
        /// </summary>
        /// <param name="val">ID</param>
        public void SetID( string val );
        /// <summary>
        /// World ID 지정
        /// </summary>
        /// <param name="val">World ID</param>
        public void SetWorldID( string val );
        /// <summary>
        /// 지역 ID 지정
        /// </summary>
        /// <param name="val">지역 ID</param>
        public void SetAreaID( string val );
        /// <summary>
        /// 스테이지 ID 지정
        /// </summary>
        /// <param name="val"></param>
        public void SetStageID( string val );
        /// <summary>
        /// 월드 이름 지정
        /// </summary>
        /// <param name="val">월드명</param>
        public void SetWorldName( string val );
        /// <summary>
        /// 지역명 지정
        /// </summary>
        /// <param name="val">지역명</param>
        public void SetAreaName( string val );
        /// <summary>
        /// 스테이지 이름 지정
        /// </summary>
        /// <param name="val">스테이지 이름</param>
        public void SetStageName( string val );

        /// <summary>
        /// 보스 스테이지 플래그 지정
        /// </summary>
        /// <param name="isVal">Boss 스테이지 여부</param>
        public void SetIsBossStage( bool isVal );

        /// <summary>
        /// 최대 턴(Hand)값 지정
        /// </summary>
        /// <param name="val">최대 턴(Hand 값)</param>
        public void SetMaxHandCount( int val );
        /// <summary>
        /// 최대 패 버리기(Discard)값 지정
        /// </summary>
        /// <param name="val"></param>
        public void SetMaxDiscardCount( int val );
        /// <summary>
        /// 클리어시 획득 가능한 골드값 지정
        /// </summary>
        /// <param name="val">골드 값</param>
        public void SetGoldValue( int val );
        /// <summary>
        /// 클리어에 필요한 스코어값 지정
        /// </summary>
        /// <param name="val">클리어에 필요한 최소 스코어값</param>
        public void SetGoalScore( int val );

        /// <summary>
        /// 클리어 여부 플래그 지정
        /// </summary>
        /// <param name="isVal">클리어 여부</param>
        public void SetIsClear( bool isVal );
    }
}
