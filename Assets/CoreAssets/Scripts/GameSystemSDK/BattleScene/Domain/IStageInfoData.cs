namespace GameSystemSDK.BattleScene.Domain
{
    public interface IStageInfoData
    {
        string ID { get; }
        string WorldID { get; }
        string AreaID { get; }
        string StageID { get; }

        string WorldName { get; }
        string AreaName { get; }
        string StageName { get; }

        bool IsBossStage { get; }

        int MaxHandCount { get; }
        int MaxDiscardCount { get; }
        int GoldValue { get; }
        int GoalScore { get; }

        bool IsClear { get; }

        public void SetID( string val );
        public void SetWorldID( string val );
        public void SetAreaID( string val );
        public void SetStageID( string val );
        public void SetWorldName( string val );
        public void SetAreaName( string val );
        public void SetStageName( string val );

        public void SetIsBossStage( bool isVal );

        public void SetMaxHandCount( int val );
        public void SetMaxDiscardCount( int val );
        public void SetGoldValue( int val );
        public void SetGoalScore( int val );

        public void SetIsClear( bool isVal );
    }
}
