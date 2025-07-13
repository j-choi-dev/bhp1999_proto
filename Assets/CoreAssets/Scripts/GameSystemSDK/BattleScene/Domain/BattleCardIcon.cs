using UnityEngine;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    /// <summary>
    /// Battle에 사용되는 카드 아이콘 클래스
    /// @Auth Choi
    /// </summary>
    public class BattleCardIcon : MonoBehaviour
    {
        public string ID { get; private set; } = string.Empty;

        public int Index { get; private set; } = 0;

        public int Type { get; private set; } = 0;

        public int Value { get; private set; } = 0;

        public string SpriteID { get; private set; } = default;


        public void SetID( string value )
            => ID = value;

        public void SetIndex( int value )
            => Index = value;

        public void SetSpriteID( string value )
            => SpriteID = value;

        public void SetType( int value )
            => Type = value;

        public void SetValue( int value )
            => Value = value;
    }
}
