using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// @Auth Choi
    /// ��Ʋ�ſ��� ���Ǵ� ��� ���ҽ��� ����� �� �ִ� â�� Ŭ����
    /// </summary>
    public interface IBattleResourceModel
    {
        /// <summary>
        /// ID�� �������� �ش� �Ϸ���Ʈ�� ��������Ʈ �̹����� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        Sprite GetIllustSprite( string id );

        /// <summary>
        /// ID�� �������� �ش� �������� ��������Ʈ �̹����� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        Sprite GetIconSprite( string id );

        /// <summary>
        /// ID�� �������� �ش� CSV�� ��ü �ؽ�Ʈ ������(Raw Text)�� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>All CSV Contents(Raw Text)</returns>
        string GetTableRawData( string id );
    }
}