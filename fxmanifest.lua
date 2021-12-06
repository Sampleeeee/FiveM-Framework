--#region Utility Functions

getmetatable( '' ).__add = function( a, b )
    return a .. b;
end

local ApplicationType = {
    Release = 1,
    Debug = 2
};

--#endregion

--#region FiveM Required

fx_version( 'cerulean' );
game( 'gta5' );

--#endregion

--#region Configuration

author( 'Sample' );
version( '0.0.1' );

local Configuration = {
    ApplicationType = ApplicationType.Debug
}

--#endregion

--#region Included Files

local buildType = Configuration.ApplicationType == ApplicationType.Release and 'Release' or 'Debug';

client_script( './Framework.Client/bin/' + buildType + '/Framework.Client.net.dll' );
server_script( './Framework.Server/bin/' + buildType + '/netstandard2.0/Framework.Server.net.dll' );
-- server_script( './Framework.Server/bin/' + buildType + '/net6.0/Newtonsoft.Json.dll' );

file( './Framework.Client/bin/' + buildType + '/Newtonsoft.Json.dll' );

--#endregion