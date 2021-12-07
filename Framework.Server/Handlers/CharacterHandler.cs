using System;
using CitizenFX.Core;
using Framework.Shared;
using Framework.Shared.Inventory;
using Framework.Shared.Items;
using Newtonsoft.Json;

namespace Framework.Server.Handlers;

// ReSharper disable once UnusedType.Global
public class CharacterHandler : BaseScript
{
    [EventHandler( "PlayerReady" )]
    private void OnPlayerReady( [FromSource] Player player )
    {
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

        character.ItemInventory = new ItemInventory( character );
        character.ItemInventory.AddItem( new TestItem(), 1 );

        string json = JsonConvert.SerializeObject( character );
        player.TriggerEvent( "SetupCharacter", json );

        character.Player = player;
        MainServer.Characters[player] = character;
    }
}