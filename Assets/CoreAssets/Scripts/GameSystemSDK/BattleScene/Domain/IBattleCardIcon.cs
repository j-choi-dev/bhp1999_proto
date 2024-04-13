namespace GameSystemSDK.BattleScene.Infrastructure
{
    public interface IBattleCardIcon
    {
        public string ID { get; }
        public int Index { get; }
        public int Type { get; }
        public int Value { get; }
        public string ResourceID { get; }

        void SetID( string value );
        void SetIndex( int value );
        void SetType( int value );
        void SetValue( int value );
        public void SetResourceID( string value );
    }
}
