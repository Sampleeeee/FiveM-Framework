using System.Collections.Generic;
using CitizenFX.Core;
using Framework.Shared;
using Newtonsoft.Json;
using System;
// using Framework.Shared.JsonConverters;

namespace Framework.Server;

// ReSharper disable once ClassNeverInstantiated.Global
public class MainServer : BaseScript
{
    public static Dictionary<Player, Character> Characters = new();
    
    public MainServer()
    {
        Log.Info( "Server has started" );
    }
}