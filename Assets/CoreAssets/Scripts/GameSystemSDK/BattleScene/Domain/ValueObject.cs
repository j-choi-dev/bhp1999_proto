using System.Linq;

namespace GameSystemSDK.BattleScene.Domain
{
    public struct HandTablePath
    {
        public readonly string StageDataMock => "StageDataMock";
        public readonly string PokerHandsCsvName => "PokerHands";
        public readonly string PokerHandsConditionCsvName => "PokerHandsCondition";
    }

    public enum CardType
    {
        Red,
        Black,
        Blue,
        Yellow,
        Max,
        None = Max
    }
    public enum PokerNumCheckType
    {
        None,
        Pair,
        Straight,
    }
    public enum OperationType
    {
        None,
        OperationAND,
        OperationOR,
        Max,
    }
}
