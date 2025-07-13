using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain
{
    /// <summary>
    /// Play 정보 데이터 클래스의 IF
    /// @Auth Choi
    /// </summary>
    public interface IPlayInfo
    {
        /// <summary>
        /// User Unique ID
        /// </summary>
        string UID { get; }
        /// <summary>
        /// Clear한 스테이지. 최종 스테이지가 아니어도 됨
        /// </summary>
        string ClearedStage { get; }
        /// <summary>
        /// 최종 로그인 시간
        /// </summary>
        string LastLogIn { get; }
        /// <summary>
        /// 상점에서 구매하는 등, 입수한 특수카드 리스트
        /// </summary>
        List<string> CurrentSpecialCardList { get; }
    }

    [System.Serializable]
    public class PlayInfo : IPlayInfo
    {
        public string uid = string.Empty;
        public string clearedStage = string.Empty;
        public string lastLogIn = string.Empty;
        public List<string> currentSpecialCardList = new List<string>();

        public string UID => uid;
        public string ClearedStage => clearedStage;
        public string LastLogIn => lastLogIn;
        public List<string> CurrentSpecialCardList => currentSpecialCardList;
    }

    [System.Serializable]
    public class TempValue
    {
        public string Key = string.Empty;
        public string Value = string.Empty;
    }
}
