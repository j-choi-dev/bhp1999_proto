using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    //public interface IBattleCardIcon
    //{
    //    public string ID { get; }
    //    public int Index { get; }
    //    public int Type { get; }
    //    public int Value { get; }
    //    public string ResourceID { get; }

    //    void SetID( string value );
    //    void SetIndex( int value );
    //    void SetType( int value );
    //    void SetValue( int value );
    //    public void SetResourceID( string value );
    //}

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
