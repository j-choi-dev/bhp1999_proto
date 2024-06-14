using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Resource.Domain
{
    /// <summary>
    /// @Auth Choi
    /// 배틀 플레이 진행에 필요한 리소스를 취득
    /// </summary>
    public interface IBattleResourceConfig
    {
        /// <summary>
        /// Table(ex: CSV) List
        /// </summary>
        IReadOnlyList<TextAsset> TableList { get; }
        IReadOnlyList<AudioClip> SoundEffectList { get; }

        /// <summary>
        /// ID를 기준으로 해당 CSV의 전체 텍스트 데이터(Raw Text)를 취득 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>All CSV Contents(Raw Text)</returns>
        IResult<string> GetTableRawData( string id );

        /// <summary>
        /// ID를 기준으로 해당 사운드 클립을 취득 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>AudioClip</returns>
        IResult<AudioClip> GetSoundEffectData( string id );
    }
}
