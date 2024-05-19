using Unity.VisualScripting;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface IBattleCard
    {
        public string ID { get; }
        public int Index { get; }
        public CardType Type { get; }
        public int Value { get; }

        public int Chip { get; }
        public string IllustResourceID { get; }
        public string IconResourceID { get; }
        public bool IsInHand { get; }
        public bool IsSelected { get; }
        public bool IsDrawn { get; }

        void SetID( string value );
        void SetIndex( int value );
        void SetType( CardType type );
        void SetValue( int value );
        void SetChip( int value );
        public void SetIllustResourceID( string sprite );
        public void SetIconResourceID( string sprite );
        public void SetInHand( bool isValue );
        public void SetIsSelected( bool isValue );
        public void SetDrawn( bool isValue );

        //public bool Equals(object obj);

        //public int GetHashCode();
    }
}
