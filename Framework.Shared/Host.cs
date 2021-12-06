using System.ComponentModel;

namespace Framework.Shared;

public static class Host
{
    public static bool IsServer
    {
        get
        {
#if SERVER
            return true;
#else
            return false;
#endif
        }
    }

    public static bool IsClient
    {
        get
        {
#if CLIENT
            return true;
#else
            return false;
#endif
        }
    }

    public static bool IsMenu
    {
        get
        {
#if MENU
            return true;
#else
            return false;
#endif
        }
    }

    public static Realm Realm
    {
        get
        {
            if ( IsServer ) return Realm.Server;
            if ( IsClient ) return Realm.Client;
            if ( IsMenu ) return Realm.Menu;

            Log.Error( "Cannot determine current realm." );
            return Realm.Unknown;
        }
    }
}

public enum Realm
{
    [Description( "Client" )] Client,
    [Description( "Server" )] Server,
    [Description( "Menu" )] Menu,
    [Description( "Unknown" )] Unknown
}