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
        List<string> CurrentPlayingCardList { get; }
        Dictionary<int, int> CurrentHandLevelDic { get; }
    }

    [System.Serializable]
    public class PlayInfo : IPlayInfo
    {
        public string uid = string.Empty;
        public string clearedStage = string.Empty;
        public string lastLogIn = string.Empty;
        public List<string> currentPlayingCardList = new List<string>();
        public Dictionary<int, int> currentHandLevelDic = new Dictionary<int, int>();

        public string UID => uid;
        public string ClearedStage => clearedStage;
        public string LastLogIn => lastLogIn;
        public List<string> CurrentPlayingCardList => currentPlayingCardList;
        public Dictionary<int, int> CurrentHandLevelDic => currentHandLevelDic;
    }

    [System.Serializable]
    public class TempValue
    {
        public string Key = string.Empty;
        public string Value = string.Empty;
    }
}
