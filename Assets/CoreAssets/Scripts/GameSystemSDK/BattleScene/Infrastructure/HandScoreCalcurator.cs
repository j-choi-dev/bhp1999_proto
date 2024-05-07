using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public class HandScoreCalcurator : IHandScoreCalcuratorDomain
    {
        private Subject<IDetailScoreInfo> _onHandScoreInfoChanged = new Subject<IDetailScoreInfo>();
        public IObservable<IDetailScoreInfo> OnDetailScoreInfo => _onHandScoreInfoChanged;

        public (int id, IReadOnlyList<IBattleCard>) GetMaxPokerScore( IReadOnlyList<IHandInfoData> handDataList,
            IReadOnlyList<IBattleCard> cardList )
        {
            var pokerHandsID = 0;
            List<IBattleCard> outCardList = new List<IBattleCard>();

            for( int i = 0; i < handDataList.Count; i++ )
            {
                List<IBattleCard> curOutCardList = new List<IBattleCard>();
                if( CheckScore( handDataList[i], cardList, curOutCardList ) )
                {
                    outCardList = curOutCardList.ToList();
                    pokerHandsID = handDataList[i].ID;
                }
            }

            return (pokerHandsID, outCardList);
        }

        public IHandConditionInfo GetPokerHandsInfoByID( IReadOnlyList<IHandInfoData> handDataList, int id )
        {
            for( int i = 0; i < handDataList.Count; i++ )
            {
                if( handDataList[i].ID.Equals( id ) == false )
                {
                    continue;
                }
                var name = handDataList[i].PairName;
                var addPoint = handDataList[i].AddPoint;
                var multiPoint = handDataList[i].MultiplePoint;
                var retVal = new HandConditionInfo( name, addPoint, multiPoint );
                return retVal;
            }
            throw new System.NullReferenceException( $"Couldn't Find {id}" );
        }

        // 旧PokerHand.IsAccept
        private bool CheckScore( IHandInfoData data,
            IReadOnlyList<IBattleCard> currCardList,
            IReadOnlyList<IBattleCard> outCardList )
        {
            var isAccept = false;
            if( outCardList == null )
            {
                outCardList = new List<IBattleCard>();
            }

            switch( data.OperationType )
            {
                case OperationType.OperationAND:
                    {
                        List<IBattleCard> curCardList = currCardList.ToList();
                        List<IBattleCard> currOutCardList = new List<IBattleCard>();
                        for( int i = 0; i < data.ConditionList.Count; i++ )
                        {
                            if( CheckCondition( data.ConditionList[i], curCardList, currOutCardList ) == false )
                            {
                                isAccept = false;
                                currOutCardList = new List<IBattleCard>();
                                break;
                            }

                            isAccept = true;
                            var target = currCardList
                                .Where( cc => outCardList.Select( oc => oc.ID ).Contains( cc.ID ));
                            currCardList.Except( target.ToList() );
                        }
                        outCardList.ToList().AddRange( currOutCardList );
                    }

                    break;
                case OperationType.OperationOR:
                    for( int i = 0; i < data.ConditionList.Count; i++ )
                    {
                        List<IBattleCard> curOutCardList = new List<IBattleCard>();
                        if( CheckCondition( data.ConditionList[i], currCardList, curOutCardList ) )
                        {
                            isAccept = true;
                            outCardList.ToList().AddRange( curOutCardList );
                            outCardList = outCardList.Distinct().ToList();
                        }
                    }
                    break;
                default:
                    var highNum = 0;
                    for( int i = 0; i < currCardList.Count; i++ )
                    {
                        if( highNum > ( int )currCardList[i].Value )
                        {
                            continue;
                        }
                        highNum = ( int )currCardList[i].Value;
                        outCardList.ToList().Add( currCardList[i] );
                    }
                    if( highNum > 0 )
                    {
                        isAccept = true;
                    }
                    break;
            }

            return isAccept;
        }

        // 旧PokerHandsCondition.IsAccept
        private bool CheckCondition( IHandConditionData condition,
            IReadOnlyList<IBattleCard> CardList,
            IReadOnlyList<IBattleCard> outCardList )
        {
            switch( condition.CheckType )
            {
                case PokerNumCheckType.Pair:
                    return HasSameNumbers( condition, CardList, outCardList );
                case PokerNumCheckType.Straight:
                    return HasConsecutiveSequence( condition, CardList, outCardList );
            }

            return NonNumbers( condition, CardList, outCardList );

        }

        private bool HasConsecutiveSequence( IHandConditionData condition,
            IReadOnlyList<IBattleCard> CardList,
            IReadOnlyList<IBattleCard> outCardList )
        {
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None && condition.CardType != ( CardType )CardList[i].Type )
                {
                    continue;
                }

                int currentCount = 1;
                outCardList.ToList().Add( CardList[i] );

                while( true )
                {
                    var card = CardList.ToList().Find( arg => arg.Value ==CardList[i].Value + currentCount &&
                        ( ( CardType )CardList[i].Type == CardType.None ||
                         ( CardType )CardList[i].Type == ( CardType )CardList[i].Type ) );
                    if( card == null )
                    {
                        break;
                    }

                    currentCount++;
                    outCardList.ToList().Add( card );
                    if( currentCount == condition.Count )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasSameNumbers( IHandConditionData condition,
            IReadOnlyList<IBattleCard> CardList,
            IReadOnlyList<IBattleCard> outCardList )
        {
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None
                    && condition.CardType != ( CardType )CardList[i].Type )
                {
                    continue;
                }

                int currentCount = 1;
                outCardList.ToList().Add( CardList[i] );

                for( int j = 0; j < CardList.Count; j++ )
                {
                    if( i == j )
                    {
                        continue;
                    }

                    if( CardList[i].Value != CardList[j].Value
                        || ( condition.CardType != CardType.None && condition.CardType != ( CardType )CardList[j].Type ) )
                    {
                        continue;
                    }

                    currentCount++;
                    outCardList.ToList().Add( CardList[j] );
                    if( currentCount == condition.Count )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool NonNumbers( IHandConditionData condition,
            IReadOnlyList<IBattleCard> CardList,
            IReadOnlyList<IBattleCard> outCardList )
        {
            int currentCount = 0;
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None && condition.CardType != ( CardType )CardList[i].Type )
                {
                    continue;
                }

                outCardList.ToList().Add( CardList[i] );
                currentCount++;

                if( currentCount == condition.Count )
                {
                    return true;
                }
            }

            return false;
        }

        public IDetailScoreInfo GetScoreData( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo condition )
        {
            var retVal = new DetailScoreInfo(cardList, condition);
            _onHandScoreInfoChanged.OnNext( retVal );
            return retVal;
        }
    }
}
