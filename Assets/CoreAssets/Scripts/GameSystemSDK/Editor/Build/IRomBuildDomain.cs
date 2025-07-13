namespace GameSystemSDK.Editor.Build.Domain
{
    /// <summary>
    /// OS별 빌드 실행 클래스의 IF
    /// @Auth Choi
    /// </summary>
	public interface IRomBuildDomain
    {
        bool PreProcess();
        bool BuildProcess();
        bool PostProcess();
    }
}
