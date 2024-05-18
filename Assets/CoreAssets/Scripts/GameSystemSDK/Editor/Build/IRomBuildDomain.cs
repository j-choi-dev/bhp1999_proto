namespace StudioRomBuild.Editor.Domain
{
	public interface IRomBuildDomain
    {
        bool PreProcess();
        bool BuildProcess();
        bool PostProcess();
    }
}
