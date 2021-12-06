using CitizenFX.Core;

namespace Framework.Shared;

public static class Log
{
    public static void Info( object obj )
    {
        if ( obj is "" ) return;
        
        Debug.WriteLine( "^4[INFO]^0: " + obj );
    }
        

    public static void Warning( object obj )
    {
        if ( obj is "" ) return;
        
        Debug.WriteLine( "^3[WARNING]^0: " + obj );
    }

    public static void Error( object obj )
    {
        if ( obj is "" ) return;
        
        Debug.WriteLine( "^1[ERROR]^0: " + obj );
    }
}