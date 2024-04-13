namespace GameSystemSDK.BattleScene.Domain
{
    public interface IBattleCard
    {
        public string ID { get; }
        public int Index { get; }
        public int Type { get; }
        public int Value { get; }
        public string IllustResourceID { get; }
        public string IconResourceID { get; }
        public bool IsInHand { get; }
        public bool IsDrawn { get; }

        void SetID( string value );
        void SetIndex( int value );
        void SetType( int value );
        void SetValue( int value );
        public void SetIllustResourceID( string sprite );
        public void SetIconResourceID( string sprite );
        public void SetInHand( bool isValue );
        public void SetDrawn( bool isValue );
    }
}
