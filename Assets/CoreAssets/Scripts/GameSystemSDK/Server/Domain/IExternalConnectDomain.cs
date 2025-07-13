using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Domain
{
    /// <summary>
    /// 외부 접속 관련 Domain
    /// @Auth Choi
    /// </summary>
    /// <remarks>Server / PlayerPrefs 등 User 정보를 보존하고 처리하는 Infrastructure는 필히 본 Interface 사용할 것</remarks>
    public interface IExternalConnectDomain
    {
        /// <summary>
        /// Play 정보가 변경될 시 발생하는 이벤트
        /// </summary>
        IObservable<IPlayInfo> OnChanged { get; }

        /// <summary>
        /// 초기화
        /// </summary>
        /// <returns>UniTask 이벤트</returns>
        UniTask Initialize();
        /// <summary>
        /// User ID 취득
        /// </summary>
        /// <returns>User ID</returns>
        UniTask<string> GetID();
        /// <summary>
        /// 최종 클리어한 Stage ID
        /// </summary>
        /// <returns>Stage ID</returns>
        UniTask<string> GetClaeredStageID();
        /// <summary>
        /// 최종 로그인 시간 갱신
        /// </summary>
        void UpdateLogInTime();
        /// <summary>
        /// 최종 로그인 시간 취득
        /// </summary>
        /// <returns>최종 로그인 시간의 문자열</returns>
        UniTask<string> GetLogInTime();
        UniTask SetEnterStage( string id );
        /// <summary>
        /// 스테이지 클리어 시, 클리어한 스테이지 ID를 지정
        /// </summary>
        /// <param name="id">최종 클리어한 스테이지 ID</param>
        UniTask SetClearedStageInfo( string id );
        /// <summary>
        /// Storage Update (Play 정보 갱신)
        /// </summary>
        /// <returns></returns>
        UniTask UpdateStorage();
        /// <summary>
        /// 유저가 보유한 카드 정보 취득
        /// </summary>
        /// <returns>카드 정보 ID 리스트</returns>
        UniTask<IReadOnlyList<string>> GetCardInfo();
        /// <summary>
        /// 카드 구매 등에 의해 추가된 카드 ID를 통해 보유 카드를 추가
        /// </summary>
        /// <param name="id">신규 획득한 카드 ID</param>
        UniTask AddCardInfo( string id );
        /// <summary>
        /// 대상 카드를 삭제
        /// </summary>
        /// <param name="id">삭제할 카드의 ID</param>
        /// <returns>UniTask</returns>
        UniTask RemoveCardInfo( string id );
        /// <summary>
        /// 보유 카드 정보를 전부 삭제
        /// </summary>
        /// <returns>UniTask</returns>
        UniTask ClearCardInfo();
        /// <summary>
        /// Stage ID 취득
        /// </summary>
        /// <returns>Stage ID</returns>
        UniTask<string> GetStageID();
    }
}
