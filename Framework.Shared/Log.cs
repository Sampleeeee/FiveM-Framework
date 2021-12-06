using System;
using System.Runtime.CompilerServices;
using CitizenFX.Core;

namespace Framework.Shared;

public static class Log
{
    public static void Info( object obj, bool showPath = false, [CallerFilePath] string path = "Unknown File",
        [CallerLineNumber] int line = -1 )
    {

        if ( obj is "" ) return;
        path = ShortenPath( path );

        Debug.WriteLine( $"^5[INFO]^0{( showPath ? $"[{path}:{line}" : "" )}: {obj}" );
    }


    public static void Warning( object obj, bool showPath = false, [CallerFilePath] string path = "Unknown File",
        [CallerLineNumber] int line = -1 )
    {

        if ( obj is "" ) return;
        path = ShortenPath( path );

        Debug.WriteLine( $"^4[WARNING]^0{( showPath ? $"[{path}:{line}]" : "" )}: {obj}" );
    }

    public static void Error( object obj, [CallerFilePath] string path = "Unknown File",
        [CallerLineNumber] int line = -1 )
    {

        if ( obj is "" ) return;
        path = ShortenPath( path );

        Debug.WriteLine( $"^1[ERROR]^0[{path}:{line}]: {obj}" );
    }

    private static string ShortenPath( string path )
    {
        path = path.Replace( "\\", "/" );

        try
        {
            return path.Substring( path.IndexOf( "/Framework", StringComparison.Ordinal ) + "Framework".Length + 2 );
        }
        catch
        {
            return path;
        }
    }
}