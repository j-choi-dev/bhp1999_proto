namespace GameSystemSDK.BattleScene.Domain
{
    public interface IBattleInfoData
    {
        string ID { get; }
        int MaxHandCount { get; }
        int MaxDiscardCount { get; }
        int GoldValue { get; }
        string StageName { get; }
        string StageBuff1 { get; }
        string StageBuff2 { get; }
        string StageBuff3 { get; }

        void SetID( string val );
        void SetMaxHandCount( int val );
        void SetMaxDiscardCount( int val );
        void SetGoldValue( int val );
        void SetStageName( string val );
        void SetStageBuff1( string val );
        void SetStageBuff2( string val );
        void SetStageBuff3( string val );
    }
}
