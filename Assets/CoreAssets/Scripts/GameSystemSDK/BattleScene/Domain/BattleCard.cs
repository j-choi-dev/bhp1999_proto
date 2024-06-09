using CoreAssetUI.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    public class BattleCard : IBattleCard
    {
        //public string ID { get; private set; } = string.Empty;

        //public CardType Type { get; private set; } = CardType.None;

        //public int Value { get; private set; } = 0;

        //public int Chip { get; private set; } = 0;

        //public string IllustResourceID { get; private set; } = string.Empty;

        //public string IconResourceID { get; private set; } = string.Empty;

        public IPlayingCardInfo PlayingCardInfo { get; private set; }
        public int Index { get; private set; } = 0;
        public bool IsInHand { get; private set; } = false;
        public bool IsSelected { get; private set; } = false;
        public bool IsDrawn { get; private set; } = false;
        public bool IsUsable { get; private set; } = true;

        //public void SetID( string value )
        //    => ID = value;

        //public void SetIllustResourceID( string sprite )
        //    => IllustResourceID = sprite;

        //public void SetType( CardType type )
        //    => Type = type;

        //public void SetValue( int value )
        //    => Value = value;

        //public void SetChip(int value)
        //    => Chip = value;

        //public void SetIconResourceID( string sprite )
        //    => IconResourceID = sprite;

        public void SetPlayingCardInfo( IPlayingCardInfo playingCardInfo )
            => PlayingCardInfo = playingCardInfo;

        public void SetIndex( int value )
            => Index = value;

        public void SetInHand( bool isValue )
            => IsInHand = isValue;

        public void SetIsSelected( bool isValue )
            => IsSelected = isValue;

        public void SetDrawn( bool isValue )
            => IsDrawn = isValue;

        public void SetUsable( bool isValue )
            => IsUsable = isValue;

        //// <TODO>
        //// 카드가 여러개 생기면 Type이랑 Value 같다고 같은 카드라고는 볼 수 없다.
        //// 카드 처음에 배포할 때 고유 UID를 생성해서 주고 그걸 비교해야 한다.
        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    if (!(obj is BattleCard))
        //    {
        //        return false;
        //    }

        //    var other = (BattleCard)obj;

        //    return Type == other.Type && Value == other.Value;
        //}

        //public override int GetHashCode()
        //{
        //    var hashCode = HashCode.Combine(Type, Value);
        //    return hashCode;
        //}
    }
}
