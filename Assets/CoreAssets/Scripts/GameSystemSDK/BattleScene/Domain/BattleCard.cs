namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Battle에 사용되는 카드 데이터 클래스
    /// @Auth Choi
    /// </summary>
    public class BattleCard : IBattleCard
    {
        public string ID { get; private set; } = string.Empty;

        public int Index { get; private set; } = 0;

        public int Type { get; private set; } = 0;

        public int Value { get; private set; } = 0;

        public int Chip { get; private set; } = 0;

        public string IllustResourceID { get; private set; } = string.Empty;

        public string IconResourceID { get; private set; } = string.Empty;

        public bool IsDrawn { get; private set; } = false;

        public bool IsInHand { get; private set; } = false;

        public bool IsSelected { get; private set; } = false;

        public void SetID( string value )
            => ID = value;

        public void SetIndex( int value )
            => Index = value;

        public void SetIllustResourceID( string sprite )
            => IllustResourceID = sprite;

        public void SetType( int value )
            => Type = value;

        public void SetValue( int value )
            => Value = value;

        public void SetChip(int value)
            => Value = value;

        public void SetDrawn( bool isValue )
            => IsDrawn = isValue;

        public void SetIconResourceID( string sprite )
            => IconResourceID = sprite;

        public void SetInHand( bool isValue )
            => IsInHand = isValue;

        public void SetIsSelected( bool isValue )
            => IsSelected = isValue;
    }
}
