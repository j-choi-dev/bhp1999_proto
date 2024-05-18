namespace GameSystemSDK.Editor.Build.Domain
{
	public interface IRomBuildDomain
    {
        bool PreProcess();
        bool BuildProcess();
        bool PostProcess();
    }
}
