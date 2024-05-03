using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// @Auth Choi
    /// 배틀신에서 사용되는 모든 리소스를 취득할 수 있는 창구 클래스
    /// </summary>
    public interface IBattleResourceModel
    {
        /// <summary>
        /// ID를 기준으로 해당 일러스트의 스프라이트 이미지를 취득 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        Sprite GetIllustSprite( string id );

        /// <summary>
        /// ID를 기준으로 해당 아이콘의 스프라이트 이미지를 취득 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        Sprite GetIconSprite( string id );

        /// <summary>
        /// ID를 기준으로 해당 CSV의 전체 텍스트 데이터(Raw Text)를 취득 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>All CSV Contents(Raw Text)</returns>
        string GetTableRawData( string id );
    }
}
