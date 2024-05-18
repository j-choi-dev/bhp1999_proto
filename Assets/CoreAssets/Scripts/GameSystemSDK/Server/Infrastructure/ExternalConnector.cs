using Cysharp.Threading.Tasks;
using GameSystemSDK.Util;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

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

        public async UniTask<IReadOnlyList<string>> GetCardInfo()
        {
            await UniTask.DelayFrame( 1 );
            return _playInfo.CurrentSpecialCardList;
        }

        public async UniTask AddCardInfo( string id )
        {
            _playInfo.CurrentSpecialCardList.Add(id);
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask RemoveCardInfo( string id )
        {
            _playInfo.CurrentSpecialCardList.Remove( id );
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask ClearCardInfo()
        {
            _playInfo.CurrentSpecialCardList.Clear();
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
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
    }
}
