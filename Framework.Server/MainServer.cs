using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using Framework.Shared;
using Framework.Shared.Items.Bases;

namespace Framework.Server;

// ReSharper disable once ClassNeverInstantiated.Global
public class MainServer : BaseScript
{
    public static Dictionary<Player, Character> Characters = new();
    
    public MainServer()
    {
        Log.Info( "Server has started" );
    }

    [Command( "print_inventory" )]
    private void PrintInventory( [FromSource] Player pl )
    {
        foreach ( KeyValuePair<BaseItem, int> kvp in Characters[pl].ItemInventory )
        {
            var item = kvp.Key;
            int amount = kvp.Value;
            
            Log.Info( $"{item.UniqueId} {amount}" );
        }
    }
}