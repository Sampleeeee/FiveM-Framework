using System;
using CitizenFX.Core;
using Framework.Shared;
using Framework.Shared.JsonConverters;
using Newtonsoft.Json;

namespace Framework.Client.Handlers;

public class CharacterHandler : BaseScript
{
    [EventHandler( "SetupCharacter" )]
    private void SetupCharacter( string json )
    {
        Log.Info( "Got SetupCharacter Event" );
        
        Log.Info( json );

        var character = JsonConvert.DeserializeObject<Character>( json, new CharacterJsonConverter() );

        Log.Info( character );
        MainClient.Character = character;
        
        Log.Info( "Assigned Character" );
    }
}