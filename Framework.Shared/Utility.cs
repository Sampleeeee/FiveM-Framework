using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Shared.Items.Bases;

namespace Framework.Shared;

public static class Utility
{
    private static readonly List<BaseItem> _itemCache = new();

    public static List<BaseItem> GetAllItems()
    {
        if ( _itemCache.Count != 0 ) return _itemCache;

        IEnumerable<Type> types = typeof( BaseItem )
            .Assembly
            .GetTypes()
            .Where( x => x.IsClass && !x.IsAbstract && x.IsSubclassOf( typeof( BaseItem ) ) );

        foreach ( var type in types )
            if ( Activator.CreateInstance( type ) is BaseItem i )
                _itemCache.Add( i );

        return _itemCache;
    }

    public static BaseItem GetItem( string uniqueId ) =>
        GetAllItems().FirstOrDefault( x => x.UniqueId == uniqueId );
}