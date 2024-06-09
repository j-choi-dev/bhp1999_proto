using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.BattleScene.Model
{
    /// <summary>
    /// 新) CardList管理Model
    /// </summary>
    /// Auth : Choi 
    public interface IBattleCardModel
    {
        /// <summary>
        /// 현재 (유효한) 카드 리스트
        /// </summary>
        IReadOnlyList<IBattleCard> CurrentCardList { get; }

        /// <summary>
        /// 현재 선택중인 카드 리스트
        /// </summary>
        IReadOnlyList<IBattleCard> CurrentSelectedList { get; }

        /// <summary>
        /// 8장 이상 구성되는 핸드 카드 리스트의 변경 이벤트
        /// </summary>
        IObservable<IReadOnlyList<IBattleCard>> OnHandCardListChanged { get; }
        /// <summary>
        /// 8장 이상 구성되는 핸드 카드의 추가 이벤트
        /// </summary>
        IObservable<IBattleCard> OnHandCardAdd { get; }
        /// <summary>a
        /// 8장 이상 구성되는 핸드 카드의 삭제 이벤트
        /// </summary>
        IObservable<IBattleCard> OnHandCardRemoved { get; }
        /// <summary>
        /// 8장 이상 구성되는 핸드 카드의 전체 삭제 이벤트
        /// </summary>
        IObservable<Unit> OnHandCardCleared { get; }

        /// <summary>
        /// 선택된 카드 리스트의 변경 이벤트
        /// </summary>
        IObservable<IReadOnlyList<IBattleCard>> OnSelectionCardListCahnged { get; }

        /// <summary>
        /// 선택된 카드 리스트의 추가 이벤트
        /// </summary>
        IObservable<IBattleCard> OnSelectedCardAdd { get; }

        /// <summary>
        /// 선택된 카드 리스트의 삭제 이벤트
        /// </summary>
        IObservable<IBattleCard> OnSelectedCardRemoved { get; }

        /// <summary>
        /// 선택된 카드 리스트의 전체 삭제 이벤트
        /// </summary>
        /// <remarks>플레이 실행 등의 이벤트 시 발생</remarks>
        IObservable<Unit> OnSelectedCardCleared { get; }

        /// <summary>
        /// 초기화 함수
        /// </summary>
        /// <returns></returns>
        UniTask Initialize();

        /// <summary>
        /// 선택된 카드 리스트에 단일 정보 추가
        /// </summary>
        /// <param name="id">선택된 카드 ID</param>
        void AddSelectedCard( string id );

        void RemoveSelectedCard( string id );

        /// <summary>
        /// 선택된 카드 리스트의 전체 삭제
        /// </summary>
        /// <remarks>플레이 실행 등의 이벤트 발생 시 삭제</remarks>
        void ClearSelectedCardList();
    }
}
