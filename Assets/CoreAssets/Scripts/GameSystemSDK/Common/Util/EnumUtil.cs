using System;

namespace CommonSystem.Util
{
    public static class EnumUtil<T>
    {
        public static T Parse( string s )
        {
            return ( T )Enum.Parse( typeof( T ), s );
        }
    }
}
