using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Infrastructure
{
    public class PlayingCardListStorage : IPlayingCardListStorageDomain
    {
        private List<IPlayingCardInfo> _playingCardList = new List<IPlayingCardInfo>();
        public IReadOnlyList<IPlayingCardInfo> PlayingCardDeckList => _playingCardList;


        public void InitPlayingCardList(IReadOnlyList<Dictionary<string, string>> rawData)
        {
            for (int i = 0; i < rawData.Count; i++)
            {
                // �� �������� �� ���� ���� ���°� ����
                var id = int.Parse(CSVUtil.GetData(rawData, i, "id"));
                var deckGroup = int.Parse(CSVUtil.GetData(rawData, i, "DeckGroup"));
                var chip = int.Parse(CSVUtil.GetData(rawData, i, "Chip"));
                var rank = int.Parse(CSVUtil.GetData(rawData, i, "Rank"));
                var suite = int.Parse(CSVUtil.GetData(rawData, i, "Suite"));

                // �׸�ī���� ���� ����ִٸ� False
                string strPicture = CSVUtil.GetData(rawData, i, "PictureCard");

                var pictureCard = strPicture.Equals(string.Empty) || strPicture == "0" ? false : true;
                string illustResourceID = CSVUtil.GetData(rawData, i, "IllustResourceID");
                string iconResourceID = CSVUtil.GetData(rawData, i, "IconResourceID");

                var data = new PlayingCardInfo(id, deckGroup, chip, rank, suite, pictureCard, illustResourceID, iconResourceID);

                _playingCardList.Add(data);
            }
        }
    }
}
