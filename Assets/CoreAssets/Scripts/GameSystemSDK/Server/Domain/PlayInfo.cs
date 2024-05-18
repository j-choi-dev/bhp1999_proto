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
        public string UID { get; set; } = string.Empty;
        public string ClearedStage { get; set; } = string.Empty;
        public string LastLogIn { get; set; } = string.Empty;
        public List<string> CurrentSpecialCardList { get; set; } = new List<string>();
    }

    [System.Serializable]
    public class TempValue
    {
        public string Key = string.Empty;
        public string Value = string.Empty;
    }
}
