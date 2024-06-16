using CommonSystem.Util;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Domain;
using GameSystemSDK.Resource.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GameSystemSDK.Card.Infrastructure
{
    public class BattleCardFactory : IBattleCardFactory
    {
        private IBattleResourceConfig _battleResourceConfig;
        private IReadOnlyList<Dictionary<string, string>> _mapper;

        public BattleCardFactory( IBattleResourceConfig battleResourceConfig )
        {
            _battleResourceConfig = battleResourceConfig;
            var path = new HandTablePath();
            var rawData = _battleResourceConfig.GetTableRawData(path.PlayingCardCsvName );
            _mapper = CSVDataConverter.ConvertProcess( rawData.Value );
        }

        public IPlayingCardInfo ConvertToBasePlayingCard( string id, string suit, string chip, string rank, string slot1, string slot2, string slot3 )
        {
            var cardId = int.Parse(id);
            var suite = EnumUtil<CardType>.Parse(suit);
            var cardChip = int.Parse(chip);
            var cardRank = int.Parse(rank);

            var retVal = new PlayingCardInfo(cardId, suite, cardChip, cardRank, slot1, slot2, slot3);
            var collumnData = new PlayingCardInfoColumnName();
            var illustId = CSVUtil.GetRowData( _mapper, collumnData.ID, id).
                First( arg => arg.key.Equals(collumnData.IllustResourceID)).value;
            retVal.SetIllustResourceID( illustId );
            return retVal;
        }

        public IBattleCard ConvertToBattleCard( IPlayingCardInfo playingCard, int index )
        {
            var data = new BattleCard();
            data.SetPlayingCardInfo( playingCard );
            data.SetIndex( index );
            return data;
        }
    }
}
