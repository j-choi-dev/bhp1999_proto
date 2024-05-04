using System.Linq;

namespace GameSystemSDK.BattleScene.Domain
{
    public struct HandTablePath
    {
        public readonly string StageDataMock => "StageDataMock";
        public readonly string PokerHandsCsvName => "PokerHands";
        public readonly string PokerHandsConditionCsvName => "PokerHandsCondition";
    }

    public struct UIMessageData
    {
        public readonly string GameOverHader => "GameOver";
        public readonly string GameOverMessage => "GameOver\n메인화면으로 돌아갑니다.";
        public readonly string Confirm => "확인";
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
