namespace GameSystemSDK.Editor.Build.Domain
{
    /// <summary>
    /// OS�� ���� ���� Ŭ������ IF
    /// @Auth Choi
    /// </summary>
	public interface IRomBuildDomain
    {
        bool PreProcess();
        bool BuildProcess();
        bool PostProcess();
    }
}
