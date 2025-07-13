using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Model
{
    /// <summary>
    /// 외부 접속 관련 Model 계층
    /// @Auth Choi
    /// </summary>
    /// <remarks>일단은 Server 접속을 가정해서, Player Prefs에 저장, 불러오는 방식으로 구현함.</remarks>
    /// <remarks>Server 엔지니어가 붙으면 변경해야 할 가능성 높음.</remarks>
    public interface IExternalConnectModel
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
        /// <summary>
        /// 스테이지 클리어 시, 클리어한 스테이지 ID를 지정
        /// </summary>
        /// <param name="id">최종 클리어한 스테이지 ID</param>
        void SetClearedStageInfo( string id );
        /// <summary>
        /// Play 정보 갱신
        /// </summary>
        /// <returns>UniTask 이벤트</returns>
        UniTask UpdateInfo();
        /// <summary>
        /// 유저가 보유한 카드 정보 취득
        /// </summary>
        /// <returns>카드 정보 ID 리스트</returns>
        UniTask<IReadOnlyList<string>> GetCardInfo();
        /// <summary>
        /// 카드 구매 등에 의해 추가된 카드 ID를 통해 보유 카드를 추가
        /// </summary>
        /// <param name="id">신규 획득한 카드 ID</param>
        void AddCardInfo( string id );
        /// <summary>
        /// Stage 진입 여부
        /// </summary>
        /// <param name="id">진입한 Stage ID</param>
        void EnterStage( string id );
    }
}
