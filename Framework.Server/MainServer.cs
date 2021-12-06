using CitizenFX.Core;
using Framework.Shared;
using Newtonsoft.Json;

namespace Framework.Server;

// ReSharper disable once UnusedType.Global
public class MainServer : BaseScript
{
    public MainServer()
    {
        Log.Info( "Server has started" );

        Log.Info( JsonConvert.SerializeObject( new
        {
            Test = "Test"
        } ) );
    }
}