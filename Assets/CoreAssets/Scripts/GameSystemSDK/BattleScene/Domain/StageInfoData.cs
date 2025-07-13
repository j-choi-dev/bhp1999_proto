namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Stage 정보 데이터 클래스
    /// @Auth Choi
    /// </summary>
    public class StageInfoData : IStageInfoData
    {
        public string ID { get; private set; } = string.Empty;
        public string WorldID { get; private set; } = string.Empty;
        public string AreaID { get; private set; } = string.Empty;
        public string StageID { get; private set; } = string.Empty;

        public string WorldName { get; private set; } = string.Empty;
        public string AreaName { get; private set; } = string.Empty;
        public string StageName { get; private set; } = string.Empty;


        public bool IsBossStage { get; private set; } = false;

        public int MaxHandCount { get; private set; } = 0;
        public int MaxDiscardCount { get; private set; } = 0;
        public int GoldValue { get; private set; } = 0;
        public int GoalScore { get; private set; } = 0; 
        
        public bool IsClear { get; private set; } = false;

        public void SetID( string val ) => ID = val;

        public void SetWorldID( string val ) => WorldID = val;
        public void SetAreaID( string val ) => AreaID = val;
        public void SetStageID( string val ) => StageID = val;

        public void SetWorldName( string val ) => WorldName = val;
        public void SetAreaName( string val ) => AreaName = val;
        public void SetStageName( string val ) => StageName = val;

        public void SetIsBossStage( bool isVal ) => IsBossStage = isVal;

        public void SetMaxHandCount( int val ) => MaxHandCount = val;
        public void SetMaxDiscardCount( int val ) => MaxDiscardCount = val;
        public void SetGoldValue( int val ) => GoldValue = val;
        public void SetGoalScore( int val ) => GoalScore = val;

        public void SetIsClear( bool isVal ) => IsClear = isVal;
    }
}
