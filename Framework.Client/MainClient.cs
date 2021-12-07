using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Framework.Shared;

namespace Framework.Client;

// ReSharper disable once ClassNeverInstantiated.Global
public class MainClient : BaseScript
{
    public static Character Character { get; set; }
    
    public MainClient()
    {
        Log.Info( "Client has started!" );
    }

    [EventHandler( "onClientResourceStart" )]
    private async void OnClientResourceStart()
    {
        while ( !API.NetworkIsPlayerActive( Game.Player.Handle ) )
            await Delay( 0 );

        TriggerServerEvent( "PlayerReady" );
    }

    [Tick]
    private Task DrawUserInterface()
    {
        if ( Character == null ) return Task.FromResult( 0 );

        const float diff = 0.075f;
        var texts = new[]
        {
            $"Name: {Character.FullName}\nJob: {{Character.Job.Name}}, {{Character.JobGrade.Name}}",
            $"Inventory Weight: {{Character.ItemInventory.GetWeight()}}\nMoney: {Character.Cash:C}",
            $"Bank: {Character.Bank:C}\nDirty Money: {Character.DirtyMoney:C}",
            $"Hunger: {Character.Hunger}\nThirst: {Character.Thirst}",
            $"Date of Birth: {Character.DateOfBirth:M/d/yyyy}, Gender: {Character.Gender}"
        };

        var current = 0.1f;
        foreach ( string text in texts )
        {
            API.SetTextScale( 0.5f, 0.5f );
            API.SetTextOutline();

            API.BeginTextCommandDisplayText( "STRING" );
            API.AddTextComponentSubstringPlayerName( text );
            API.EndTextCommandDisplayText( 0f, 0f + current );

            current += diff;
        }

        return Task.FromResult( 0 );
    }
}