using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace Framework.Shared.Extensions;

public static class JObjectX
{
    public static T ReadFromJson<T>( this JObject jObject, string key, T defaultValue = default,
        [CallerFilePath] string path = "Unknown File",
        [CallerLineNumber] int line = -1 )
    {
        if ( !jObject.ContainsKey( key ) )
        {
            // ReSharper disable twice ExplicitCallerInfoArgument
            Log.Error( $"Could not read key '{key}'", path, line );
            return defaultValue;
        }

        try
        {
            return jObject[key].ToObject<T>();
        }
        catch ( Exception e )
        {
            Log.Error( $"Failed to convert to object. Key: {key} " );
            return defaultValue;
        }
    }
}