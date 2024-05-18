using System.Linq;

namespace GameSystemSDK.BattleScene.Domain
{
    public struct HandTablePath
    {
        public readonly string StageDataMock => "StageDataMock";
        public readonly string PokerHandsCsvName => "PokerHands";
        public readonly string PokerHandsConditionCsvName => "PokerHandsCondition";
        public readonly string PlayingCardCsvName => "PlayingCard";
        public readonly string CardUpgradeCsvName => "CardUpgrade";
        public readonly string CardEffectCsvName => "CardEffect";
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

    public enum  CardUpgradeType
    {
        Enhancement,    // 강화 혹은 부여
        Edition,        // 카드 특수 처리(포일 같은 거)
        Seal,           // 봉인 추가
        Max,
    }

    public enum ActivateConditionType
    {
        WhenTrigger,    // 카드 자체가 트리거되는 시점
        RoundEnd,       // 라운드 끝났을 때 손에 보유하고 있다면
        CardPlayGetPoint,   // 득점에 사용된 카드 체크
        Discard,        // 버렸을 때
    }

    public enum CardEffectOperationType
    {
        Chip,           // AddPoint 추가
        Multiplier,     // MultiPoint 추가
        ChangeSuite,    // CardType 변경
        ChangeRank,     // Card Num 변경
        Xmultiplier,    // MultiPoint 배수
        Destroy,        // 해당 카드 파괴
        Dollar,         // 돈
        AdditionalTrigger,  // 한 번 더 트리거
        GenerateItem,   // 아이템 생성(행성과 타로는 OperationParam으로 구분하자?)
    }
}
