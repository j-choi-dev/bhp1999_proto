using GameSystemSDK.Common.Domain;
using System.Collections.Generic;
using UnityEngine;


namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// ��Ʋ �÷��� ���࿡ �ʿ��� ���ҽ��� ���
    /// @Auth Choi
    /// </summary>
    public interface IBattleResourceContext
    {
        /// <summary>
        /// Card Illust List
        /// </summary>
        IReadOnlyList<Sprite> CardIllustList { get; }

        /// <summary>
        /// Card Icon Illust List
        /// </summary>
        IReadOnlyList<Sprite> CardIconList { get; }

        /// <summary>
        /// Table(ex: CSV) List
        /// </summary>
        IReadOnlyList<TextAsset> TableList { get; }

        /// <summary>
        /// ID�� �������� �ش� �Ϸ���Ʈ�� ��������Ʈ �̹����� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        IResult<Sprite> GetIllustSprite( string id );

        /// <summary>
        /// ID�� �������� �ش� �������� ��������Ʈ �̹����� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Sprite</returns>
        IResult<Sprite> GetIconSprite( string id );

        /// <summary>
        /// ID�� �������� �ش� CSV�� ��ü �ؽ�Ʈ ������(Raw Text)�� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>All CSV Contents(Raw Text)</returns>
        IResult<string> GetTableRawData( string id );

        /// <summary>
        /// ID�� �������� �ش� ���� Ŭ���� ��� 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>AudioClip</returns>
        IResult<AudioClip> GetSoundEffectData( string id );
    }
}
