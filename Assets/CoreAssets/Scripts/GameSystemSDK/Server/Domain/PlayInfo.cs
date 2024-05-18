using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain
{
    public interface IPlayInfo
    {
        string UID { get; }
        string ClearedStage { get; }
        string LastLogIn { get; }
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
