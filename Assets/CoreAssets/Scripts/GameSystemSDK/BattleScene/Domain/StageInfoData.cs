namespace GameSystemSDK.BattleScene.Domain
{
    public class StageInfoData : IStageInfoData
    {
        public string ID { get; private set; } = string.Empty;
        public int MaxHandCount { get; private set; } = 0;
        public int MaxDiscardCount { get; private set; } = 0;
        public int GoldValue { get; private set; } = 0;
        public string StageName { get; private set; } = string.Empty;
        public string StageBuff1 { get; private set; } = string.Empty;
        public string StageBuff2 { get; private set; } = string.Empty;
        public string StageBuff3 { get; private set; } = string.Empty;

        public void SetID( string val ) => ID = val;
        public void SetMaxHandCount( int val ) => MaxHandCount = val;
        public void SetMaxDiscardCount( int val ) => MaxDiscardCount = val;
        public void SetGoldValue( int val ) => GoldValue = val;
        public void SetStageName( string val ) => StageName = val;
        public void SetStageBuff1( string val ) => StageBuff1 = val;
        public void SetStageBuff2( string val ) => StageBuff2 = val;
        public void SetStageBuff3( string val ) => StageBuff3 = val;
    }
}
