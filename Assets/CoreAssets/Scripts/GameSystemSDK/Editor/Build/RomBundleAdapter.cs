using StudioRomBuild.Editor.Domain;
using UnityEngine;

namespace StudioRomBuild.Editor.Application
{
	public class RomBundleAdapter
	{
		private IRomBuildDomain m_Builder;

		public RomBundleAdapter( IRomBuildDomain builder )
		{
			m_Builder = builder;
		}

		public bool BuildAssetBundle()
		{
			Debug.Log( "Application Build Start" );
			if( !m_Builder.PreProcess() )
			{
				Debug.LogError( "Application Build PreProcess Failed" );
				return false;
			}
			if( !m_Builder.BuildProcess() )
			{
				Debug.LogError( "Application Build BuildProcess Failed" );
				return false;
			}
			if( !m_Builder.PostProcess() )
			{
				Debug.LogError( "Application Build PostProcess Failed" );
				return false;
			}
			return true;
		}
	}
}
