using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Shared.Items.Bases;

namespace Framework.Shared.Inventory;

public class ItemInventory : IEnumerable<KeyValuePair<BaseItem, int>>
{
    public Character Owner { get; set; }

    private readonly List<Type> _items = new();
    private readonly List<int> _values = new();

    public ItemInventory( Character owner )
    {
        Owner = owner;
    }

    public void AddItem( Type type, int amount = 1 )
    {
        if ( type is null || !type.IsSubclassOf( typeof( BaseItem ) ) ) return;

        if ( this._items.Contains( type ) )
        {
            int location = this._items.IndexOf( type );
            this._values[location] += amount;
        }
        else
        {
            this._items.Add( type );
            this._values.Insert( this._items.IndexOf( type ), amount );
        }

        #if SERVER
        if ( Owner?.Player is null ) return;
        
        Owner.Player.TriggerEvent( "ItemInventoryUpdated", type.FullName, amount );
        #endif
    }

    public bool HasItem( Type type, int amount = 1 )
    {
        if ( !this._items.Contains( type ) ) return false;
        return this._values[this._items.IndexOf( type )] >= amount;
    }

    public int GetCount( Type type )
    {
        return !_items.Contains( type ) ? 0 : _values[_items.IndexOf( type )];
    }

    public void AddItem( BaseItem item, int amount ) => AddItem( item.GetType(), amount );

    public void TakeItem( Type type, int amount ) => AddItem( type, -amount );
    public void TakeItem( BaseItem item, int amount ) => AddItem( item.GetType(), -amount );
    
    public bool HasItem( BaseItem item, int amount = 1 ) => HasItem( item.GetType(), amount );

    public int GetCount( BaseItem item ) => GetCount( item.GetType() );

    #region IEnumerator

    public IEnumerator<KeyValuePair<BaseItem, int>> GetEnumerator()
    {
        return new ItemInventoryEnumerator( this._items, this._values );
    }

    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator1();
    }

    #endregion
}

public class ItemInventoryEnumerator : IEnumerator<KeyValuePair<BaseItem, int>>
{
    private int _position = 0;
    private List<Type> _items;
    private List<int> _values;

    private KeyValuePair<BaseItem, int>? _current;

    public KeyValuePair<BaseItem, int> Current
    {
        get
        {
            if ( this._current == null )
                throw new InvalidOperationException();

            return ( KeyValuePair<BaseItem, int> )this._current;
        }
    }

    private object Current1 => this.Current;
    object IEnumerator.Current => this.Current1;

    public ItemInventoryEnumerator( List<Type> items, List<int> values )
    {
        this._items = items;
        this._values = values;
    }

    public bool MoveNext()
    {
        if ( this._items.Count <= 0 ) return false;
        if ( this._items.Count < this._position + 1 ) return false;

        object instance = Activator.CreateInstance( this._items[this._position] );

        if ( instance is BaseItem i ) this._current = new KeyValuePair<BaseItem, int>( i, this._values[this._position] );

        this._position++;
        return true;
    }

    public void Reset()
    {
        this._position = 0;
        this._current = null;
    }
    
    public void Dispose()
    {
    }

    ~ItemInventoryEnumerator() => this.Dispose();
}