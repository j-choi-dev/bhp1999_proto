using System.IO;
using Cysharp.Threading.Tasks;

namespace GameSystemSDK.Util
{
    public static class FileIOUtil
    {
        public static async UniTask<byte[]> Load( string path )
        {
			var bytes = await File.ReadAllBytesAsync( path );
			return bytes;
        }

        public static async UniTask Save( string path, byte[] bytes )
        {
            await File.WriteAllBytesAsync( path, bytes );
        }

        public static async UniTask SaveText( string path, string text )
		{
			await File.WriteAllTextAsync( path, text );
        }

        public static async UniTask<string> LoadText( string path )
        {
			var text = await File.ReadAllTextAsync( path );
            return text;
		}

		public static bool IsExist(string path)
		{
			return File.Exists( path );
		}

		public static void CreateNewFile( string path )
		{
			File.Create(path);
		}

		public static bool CopyFile( string sourcePath, string destPath )
		{
			try
			{
				CreateDirectoryIfNotExists( Path.GetDirectoryName( destPath ) );
				File.Copy( sourcePath, destPath, true );
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void CreateDirectoryIfNotExists( string destPath )
		{
			if( Directory.Exists( destPath ) )
			{
				return;
			}
			Directory.CreateDirectory( destPath );
		}

		public static void MoveOverwrite( string sourceFileName, string destFileName )
		{
			if( File.Exists( destFileName ) )
			{
				File.Delete( destFileName );
			}
			File.Move( sourceFileName, destFileName );
		}

		// TODO 이런 방법도 있을것 같음 @Choi
		//public static UniTask<string> LoadText( string path )
		//{
		//	var text = File.ReadAllText( path );
		//	return UniTask.FromResult( text );
		//}
	}
}
