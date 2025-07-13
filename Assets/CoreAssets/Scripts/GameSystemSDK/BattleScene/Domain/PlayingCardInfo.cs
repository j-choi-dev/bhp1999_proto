using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    ///  플레잉 카드 데이터
    ///  @Auth Samdong
    /// </summary>
    public interface IPlayingCardInfo
    {
        int ID { get; }
        int DeckGroup { get; }
        int Chip { get; }
        int Rank { get; }
        int Suite { get; }
        bool PictureCard { get; }
        string IllustResourceID { get; }
        string IconResourceID { get; }
    }

    public class PlayingCardInfo : IPlayingCardInfo
    {
        public int ID { get; private set; }
        public int DeckGroup { get; private set; }
        public int Chip { get; private set; }
        public int Rank { get; private set; }
        public int Suite { get; private set; }
        public bool PictureCard { get; private set; }
        public string IllustResourceID { get; private set; }
        public string IconResourceID { get; private set; }

        public PlayingCardInfo(int id,
            int deckGroup,
            int chip,
            int rank,
            int suite,
            bool pictureCard,
            string illustResourceID,
            string iconResourceID)
        {
            this.ID = id;
            this.DeckGroup = deckGroup;
            this.Chip = chip;
            this.Rank = rank;
            this.Suite = suite;
            this.PictureCard = pictureCard;
            this.IllustResourceID = illustResourceID;
            this.IconResourceID = iconResourceID;
        }
    }
}