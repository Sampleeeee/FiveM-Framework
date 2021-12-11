using System;
using CitizenFX.Core;
using Framework.Shared;
using Framework.Shared.JsonConverters;
using Newtonsoft.Json;

namespace Framework.Client.Handlers;

public class CharacterHandler : BaseScript
{
    [EventHandler( "SetupCharacter" )]
    private async void SetupCharacter( string json )
    {
        var character = JsonConvert.DeserializeObject<Character>( json );
        MainClient.Character = character;
        character.Player = Game.Player;
    }
}