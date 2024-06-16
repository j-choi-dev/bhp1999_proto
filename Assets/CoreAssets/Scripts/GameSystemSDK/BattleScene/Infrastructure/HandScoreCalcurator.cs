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

        // <TODO>
        // 일단 무조건 1레벨 득점을 돌려준다.
        // 현재 레벨 구현하면 더 올려서 주도록 하자.
        public IHandConditionInfo GetPokerHandsInfoByID( IReadOnlyList<IHandInfoData> handDataList, int id, int handsLevel )
        {
            for( int i = 0; i < handDataList.Count; i++ )
            {
                if( handDataList[i].ID.Equals( id ) == false )
                {
                    continue;
                }
                var name = handDataList[i].PairName;
                var addPoint = handDataList[i].HandLevelDictionary[handsLevel].AddPoint;
                var multiPoint = handDataList[i].HandLevelDictionary[handsLevel].MultiplePoint;
                var retVal = new HandConditionInfo( name, handsLevel, addPoint, multiPoint );
                return retVal;
            }

            return null;
        }

        // 旧PokerHand.IsAccept
        private bool CheckScore( IHandInfoData data,
            IReadOnlyList<IBattleCard> inputCurCardList,
            List<IBattleCard> outCardList )
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
                        List<IBattleCard> curCardList = inputCurCardList.ToList();
                        List<IBattleCard> currOutCardList = new List<IBattleCard>();
                        for( int i = 0; i < data.ConditionList.Count; i++ )
                        {
                            if( CheckCondition( data.ConditionList[i], curCardList, currOutCardList ) == false )
                            {
                                isAccept = false;
                                currOutCardList.Clear();
                                break;
                            }

                            isAccept = true;
                            curCardList = curCardList.Except( currOutCardList ).ToList();
                        }
                        outCardList.AddRange( currOutCardList );
                    }

                    break;
                case OperationType.OperationOR:
                    for( int i = 0; i < data.ConditionList.Count; i++ )
                    {
                        List<IBattleCard> curOutCardList = new List<IBattleCard>();
                        if( CheckCondition( data.ConditionList[i], inputCurCardList, curOutCardList ) )
                        {
                            isAccept = true;
                            outCardList.AddRange( curOutCardList );
                            outCardList = outCardList.Distinct().ToList();
                        }
                    }
                    break;
                default:
                    var highNum = 0;
                    for( int i = 0; i < inputCurCardList.Count; i++ )
                    {
                        if( highNum > inputCurCardList[i].Value )
                        {
                            continue;
                        }
                        highNum = inputCurCardList[i].Value;
                        outCardList.Clear();
                        outCardList.Add(inputCurCardList[i] );
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
            List<IBattleCard> outCardList )
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
            List<IBattleCard> outCardList )
        {
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None && condition.CardType != CardList[i].Type )
                {
                    continue;
                }

                int currentCount = 1;
                outCardList.Add( CardList[i] );

                while( true )
                {
                    var card = CardList.ToList().Find( arg => arg.Value == CardList[i].Value + currentCount &&
                        ( CardList[i].Type == CardType.None || CardList[i].Type == CardList[i].Type ) );
                    if( card == null )
                    {
                        break;
                    }

                    currentCount++;
                    outCardList.Add( card );
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
            List<IBattleCard> outCardList )
        {
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None && condition.CardType != CardList[i].Type )
                {
                    continue;
                }

                int currentCount = 1;
                outCardList.Add( CardList[i] );

                for( int j = 0; j < CardList.Count; j++ )
                {
                    if( i == j )
                    {
                        continue;
                    }

                    if( CardList[i].Value != CardList[j].Value
                        || ( condition.CardType != CardType.None && condition.CardType != CardList[j].Type ) )
                    {
                        continue;
                    }

                    currentCount++;
                    outCardList.Add( CardList[j] );
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
            List<IBattleCard> outCardList )
        {
            int currentCount = 0;
            for( int i = 0; i < CardList.Count; i++ )
            {
                if( condition.CardType != CardType.None && condition.CardType != CardList[i].Type )
                {
                    continue;
                }

                outCardList.Add( CardList[i] );
                currentCount++;

                if( currentCount == condition.Count )
                {
                    return true;
                }
            }

            return false;
        }

        public IDetailScoreInfo GetScoreData(IHandConditionInfo condition )
        {
            var retVal = new DetailScoreInfo(condition);
            _onHandScoreInfoChanged.OnNext( retVal );
            return retVal;
        }
    }
}
