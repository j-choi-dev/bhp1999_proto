using Cysharp.Threading.Tasks;
using GameSystemSDK.Util;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using GameSystemSDK.BattleScene.Domain;

namespace GameSystemSDK.Server.Infrastructure
{

    public class ExternalConnector : IExternalConnectDomain
    {
        private readonly string Path = UnityEngine.Application.persistentDataPath;
        private readonly string PlayerInfoFileName = "playerInfo.conf";
        private readonly string TempFileName = "temp.conf";
        private string _playerInfoPath = string.Empty;
        private string _tempPath = string.Empty;

        private Subject<IPlayInfo> _onChanged = new Subject<IPlayInfo>();
        public IObservable<IPlayInfo> OnChanged => _onChanged;

        private PlayInfo _playInfo = null;

        public ExternalConnector()
        {
            _playerInfoPath = System.IO.Path.Combine( Path, PlayerInfoFileName );
            _tempPath = System.IO.Path.Combine( Path, TempFileName );
        }

        public async UniTask Initialize()
        {
            if( FileIOUtil.IsExist( _playerInfoPath ) == false )
            {
                FileIOUtil.CreateNewFile( _playerInfoPath );
                _playInfo = new PlayInfo();
                Debug.Log( $"Initialize(New User)" );
                return;
            }
            var text = await FileIOUtil.LoadText( _playerInfoPath );
            _playInfo = SerializeUtil.FromJson<PlayInfo>( text );
            Debug.Log( $"Initialize(User Exist)\n{_playerInfoPath}\n{text}" );
            _onChanged.OnNext( _playInfo );
        }

        public async UniTask<string> GetID()
        {
            if( string.IsNullOrEmpty( _playInfo.UID ) )
            {
                _playInfo.uid = SystemInfo.deviceUniqueIdentifier;
            }
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.UID;
        }

        public async UniTask<string> GetClaeredStageID()
        {
            if( string.IsNullOrEmpty( _playInfo.ClearedStage ) )
            {
                _playInfo.clearedStage = "0";
            }
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.ClearedStage;
        }

        public async UniTask<string> GetLogInTime()
        {
            await UniTask.DelayFrame( 1 );

            _playInfo.lastLogIn = System.DateTime.UtcNow.Millisecond.ToString();
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.LastLogIn;
        }

        public void UpdateLogInTime()
        {
            _playInfo.lastLogIn = System.DateTime.UtcNow.Millisecond.ToString();
            UpdateStorage().Forget();
        }

        public async UniTask UpdateStorage()
        {
            var text = SerializeUtil.ToJson(_playInfo);
            await FileIOUtil.SaveText( _playerInfoPath, text );
        }

        public IReadOnlyList<string> GetCardInfo()
        {
            return _playInfo.CurrentPlayingCardList;
        }

        public async UniTask SetCardInfo(IReadOnlyList<IPlayingCardInfo> cardInfoList)
        {
            //<TODO>
            //지금은 그냥 임시로 카드 ID만 저장합니다.
            //나중에는 카드 업그레이드 인포도 변환하여 저장 필요합니다. 
            _playInfo.CurrentPlayingCardList.Clear();
            foreach(var plyingCard in cardInfoList)
            {
                _playInfo.CurrentPlayingCardList.Add(plyingCard.ID.ToString());
            }
            await UpdateStorage();
            await UniTask.DelayFrame(1);
        }

        public async UniTask AddCardInfo( string id )
        {
            _playInfo.CurrentPlayingCardList.Add(id);
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask RemoveCardInfo( string id )
        {
            _playInfo.CurrentPlayingCardList.Remove( id );
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask ClearCardInfo()
        {
            _playInfo.CurrentPlayingCardList.Clear();
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask ChangeCardInfo(string id1, string id2 )
        {
            await RemoveCardInfo(id1);
            await AddCardInfo(id2);
        }

        public async UniTask SetEnterStage( string id )
        {
            var tempValue = new TempValue();
            tempValue.Key = "stage";
            tempValue.Value = id;

            var text = SerializeUtil.ToJson(tempValue);
            await FileIOUtil.SaveText( _tempPath, text );
            Debug.Log( $"(가라)Server 송신 -> {text}" );
        }

        public async UniTask SetClearedStageInfo( string id )
        {
            if( _playInfo.ClearedStage.CompareTo( id ) >= 0 )
            {
                return;
            }
            _playInfo.clearedStage = id;
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask<string> GetStageID()
        {
            var text = await FileIOUtil.LoadText( _tempPath );
            var retVal = SerializeUtil.FromJson<TempValue>( text );
            Debug.Log( $"(가라)Server 수신 -> {text}" );
            return retVal.Value;
        }

        public async UniTask AddHandLevel( int handsID, int addHandsLevel )
        {
            int curHandsLevel = 1;
            if(_playInfo.CurrentHandLevelDic.TryGetValue(handsID, out curHandsLevel) == true )
            {
                _playInfo.CurrentHandLevelDic.Remove(handsID);
            }

            curHandsLevel -= addHandsLevel;
            if( curHandsLevel < 1 )
            {
                curHandsLevel = 1;
            }

            _playInfo.CurrentHandLevelDic.Add(handsID, curHandsLevel);

            await UpdateStorage();
            await UniTask.DelayFrame(1);
        }

        // <TODO> 지금은 초기화 단계가 꼬여서(HandLevel 데이터를 먼저 로딩해야 하는데..)
        // 임시로 없는 데이터 달라고 하면 레벨1을 준다.
        public int GetHandLevel(int handsID)
        {
            int curHandsLevel = 0;
            if (_playInfo.CurrentHandLevelDic.TryGetValue(handsID, out curHandsLevel) == false )
            {
                return 2;
            }

            return curHandsLevel;
        }
    }
}
