using System;
using CitizenFX.Core;
using Framework.Shared;
using Newtonsoft.Json;

namespace Framework.Server.Handlers;

// ReSharper disable once UnusedType.Global
public class CharacterHandler : BaseScript
{
    [EventHandler( "PlayerReady" )]
    private void OnPlayerReady( [FromSource] Player player )
    {
        Log.Info( "Got server event PlayerReady" );

        var character = new Character
        {
            FirstName = "Jon",
            LastName = "Doe",
            Cash = 10_000,
            Bank = 10_000,
            DirtyMoney = 10_000,
            Hunger = 100,
            Thirst = 100,
            DateOfBirth = DateTime.Parse( "02/18/2000" ),
            Gender = Gender.Male,
        };

        string json = JsonConvert.SerializeObject( character );

        Log.Info( json );
        
        player.TriggerEvent( "SetupCharacter", json );

        character.Player = player;
        MainServer.Characters[player] = character;

        Log.Info( "Sent Back Character" );
    }
}