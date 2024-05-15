using Cysharp.Threading.Tasks;
using GameSystemSDK.IO.Util;
using GameSystemSDK.Serialization.Util;
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

            if( FileIOUtil.IsExist( _playerInfoPath ) == false )
            {
                FileIOUtil.CreateNewFile( _playerInfoPath );
                _playInfo = new PlayInfo();
            }
        }

        public async UniTask Initialize()
        {
            if( FileIOUtil.IsExist( _playerInfoPath ) == false )
            {
                FileIOUtil.CreateNewFile( _playerInfoPath );
                _playInfo = new PlayInfo();
                return;
            }
            var bytes = await FileIOUtil.Load( _playerInfoPath );
            _playInfo = bytes.Length > 0 ?
                SerializeUtil.Deserialize<PlayInfo>( bytes ) :
                new PlayInfo();
            _onChanged.OnNext( _playInfo );
            Debug.Log( $"Initialize ... Path : {_playerInfoPath}, bytes : {bytes.Length}, {_playInfo.UID}, {_playInfo.ClearedStage}" );
        }

        public async UniTask<string> GetID()
        {
            if( string.IsNullOrEmpty( _playInfo.UID ) )
            {
                _playInfo.UID = SystemInfo.deviceUniqueIdentifier;
            }
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.UID;
        }

        public async UniTask<string> GetClaeredStageID()
        {
            if( string.IsNullOrEmpty( _playInfo.ClearedStage ) )
            {
                _playInfo.ClearedStage = "0";
            }
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.ClearedStage;
        }

        public async UniTask<string> GetLogInTime()
        {
            await UniTask.DelayFrame( 1 );

            _playInfo.LastLogIn = System.DateTime.UtcNow.Millisecond.ToString();
            await UpdateStorage();
            _onChanged.OnNext( _playInfo );
            return _playInfo.LastLogIn;
        }

        public void UpdateLogInTime()
        {
            _playInfo.LastLogIn = System.DateTime.UtcNow.Millisecond.ToString();
            UpdateStorage().Forget();
        }

        public async UniTask UpdateStorage()
        {
            var saveData = SerializeUtil.Serialize(_playInfo);
            await FileIOUtil.Save( _playerInfoPath, saveData );
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
            Debug.Log( $"파일->JSON 변환2\n{text}" );

            await FileIOUtil.SaveText( _tempPath, text );
            Debug.Log( "(가라)Server 송신 -> 배틀신 이동(배틀신 초기화 시, (가라)Server로부터 수신)" );
        }

        public async UniTask SetClearedStageInfo( string id )
        {
            if( _playInfo.ClearedStage.CompareTo( id ) >= 0 )
            {
                return;
            }
            _playInfo.ClearedStage = id;
            Debug.Log( $"SetClearedStageInfo ... {_playInfo.ClearedStage}" );
            await UpdateStorage();
            await UniTask.DelayFrame( 1 );
        }

        public async UniTask<string> GetStageID()
        {
            var text = await FileIOUtil.LoadText( _tempPath );
            Debug.Log( $"JSON->파일 변환\n{text}" );
            var retVal = SerializeUtil.FromJson<TempValue>( text );
            Debug.Log( $"(가라)Server 수신 -> {retVal.Key}, {retVal.Value}" );
            return retVal.Value;
        }
    }
}
