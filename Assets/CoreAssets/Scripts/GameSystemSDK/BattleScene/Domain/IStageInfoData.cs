namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// @Auth Choi
    /// Stage Info Data
    /// </summary>
    public interface IStageInfoData
    {
        /// <summary>
        /// Stage Info Unique ID
        /// </summary>
        string ID { get; }

        /// <summary>
            /// 해당 스테이지에서의 최대 Hand Count
        /// </summary>
        int MaxHandCount { get; }

        /// <summary>
            /// 해당 스테이지에서의 최대 카드 버리기 실행 가능 Count
        /// </summary>
        int MaxDiscardCount { get; }

        /// <summary>
            /// 해당 스테이지에서의 골드 값
        /// </summary>
        int GoldValue { get; }

        /// <summary>
            /// 해당 스테이지의 표시명
        /// </summary>
        string StageName { get; }

        /// <summary>
            /// 해당 스테이지의 효과 설명 데이터 1
        /// </summary>
        string StageBuff1 { get; }

        /// <summary>
            /// 해당 스테이지의 효과 설명 데이터 2
        /// </summary>
        string StageBuff2 { get; }

        /// <summary>
            /// 해당 스테이지의 효과 설명 데이터 3
        /// </summary>
        string StageBuff3 { get; }

        /// <summary>
            ///  ID 대입
        /// </summary>
        /// <param name="val">string type ID Value</param>
        void SetID( string val );

        /// <summary>
            ///  최대 Hand Count 대입
        /// </summary>
        /// <param name="val">int type Count Value</param>
        void SetMaxHandCount( int val );

        /// <summary>
            ///  최대 카드 버리기 Count 대입
        /// </summary>
        /// <param name="val">int type Count Value</param>
        void SetMaxDiscardCount( int val );

        /// <summary>
            ///  Gold 대입
        /// </summary>
        /// <param name="val">int type Gold Value</param>
        void SetGoldValue( int val );

        /// <summary>
            ///  Gold 대입
        /// </summary>
        /// <param name="val">string type Stage Name</param>
        void SetStageName( string val );

        /// <summary>
            ///  Gold 대입
        /// </summary>
        /// <param name="val">string type Stage Buff Effect 1</param>
        void SetStageBuff1( string val );

        /// <summary>
            ///  Gold 대입
        /// </summary>
        /// <param name="val">string type Stage Buff Effect 2</param>
        void SetStageBuff2( string val );

        /// <summary>
            ///  Gold 대입
        /// </summary>
        /// <param name="val">string type Stage Buff Effect 3</param>
        void SetStageBuff3( string val );
    }
}
