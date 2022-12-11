// Tribes 1.41 console.cs
// Reworked by Shayk-N'-Bake
// https://github.com/shaykbake/

// $console::logmode = 1; // log by default
$BaseServerType = true; // list "base" under Server Type if nothing defined in $modList, otherwise will allow to be blank

// for any additional maps added into their own *type* and *type/missions* sub-directories, list the name of the folder housing those files under the *maps/* directory
// each directory must be "one word" only with spaces between each entry
$ExtendedMaps = "Balanced DOX LT OpenCall OpenCall2 OpenCall3";

//-----------------------------------
//
// Tribes startup
//
//-----------------------------------

// exportFunctions("*", "docs/functions.core.txt"); // export functions to "docs/functions.core.txt" file at startup


//-----------------------------------------------------------------------------
// Bootstrap namespace
//-----------------------------------------------------------------------------

// adds the TRIBES/mods directory to search path
function Bootstrap::getModEvalPath( %modName )
{
    echo(sprintf("Adding mod '%1' to eval path.", %modName));

    %modEvalPaths = "missions scripts";
    %modName = "mods/" @ %modName; // point to the "mods" directory

    // Base directory
    %resultPath = %modName @ ";";
    %modName = %modName @ "/";

    for(%i = 0; (%path = getWord(%modEvalPaths, %i)) != -1; %i++)
        %resultPath = %resultPath @ %modName @ %path @ ";";

    return %resultPath;
}

// adds the TRIBES/GameData directory to search path (replaced "base" directory)
function Bootstrap::getGameDataEvalPath()
{
    %modEvalPaths = "missions fonts skins voices scripts Entities huds";

    %resultPath = "GameData;";

    for(%i = 0; (%path = getWord(%modEvalPaths, %i)) != -1; %i++)
        %resultPath = %resultPath @ "GameData/" @ %path @ ";";

    return %resultPath;
}

// adds the extended map directories located within the TRIBES/maps directory to search path based on $ExtendedMaps variable
function Bootstrap::getExtendedMapsPath()
{
    for(%i = 0; (%type = getWord($ExtendedMaps, %i)) != -1; %i++)
    {
        %typePath = sprintf("maps/%1;maps/%1/%2;", %type, "missions");
        if(String::Empty(%resultPath))
            %resultPath = %typePath;
        else
            %resultPath = %resultPath @ %typePath;
    }
    return %resultPath;
}

function Bootstrap::clearModList()
{
    $modList = "";
    $modCount = 0;
}

function Bootstrap::addMod( %modName )
{
    echo(sprintf("Adding mod: %1.", %modName));
    
    // Only add once
    if(string::findsubstr( $modList, %modName ) == -1)
    {
        $modCount++;
        if(String::Empty($modList))
            $modList = %modName;
        else
            $modList = sprintf("%1 %2", %modName, $modList);
    }
}

function Bootstrap::evalSearchPath()
{
    // search path always contains the config directory
    %searchPath = "config;mods;recordings;temp;";

    // Append mod paths
    for(%i = 0; (%word = getWord($modList, %i)) != -1; %i++)
        %searchPath = %searchPath @ Bootstrap::getModEvalPath(%word);
    
    // add "GameData" directory to search path
    %searchPath = %searchPath @ Bootstrap::getGameDataEvalPath();

    %searchPath = %searchPath @ "maps;maps/missions;"; // add "maps" directory
    %searchPath = %searchPath @ Bootstrap::getExtendedMapsPath(); // add extended maps paths configured using $ExtendedMaps variable

    // Print search to console
    echo("SearchPath : " @ %searchPath);

    // Set path
    $ConsoleWorld::DefaultSearchPath = %searchPath;

    // clear out the volumes:
    for(%i = 0; isObject(%vol = "VoiceVolume" @ %i); %i++)
        deleteObject(%vol);
    for(%i = 0; isObject(%vol = "SkinVolume" @ %i); %i++)
        deleteObject(%vol);

    // load all the volumes:
    %file = File::findFirst("voices/*.zip");
    for(%i = 0; %file != ""; %file = File::findNext("voices/*.zip"))
        if(newObject("VoiceVolume" @ %i, SimVolume, %file))
            %i++;

    %file = File::findFirst("skins/*.zip");
    for(%i = 0; %file != ""; %file = File::findNext("skins/*.zip"))
        if(newObject("SkinVolume" @ %i, SimVolume, %file))
            %i++;
}

// note that any value within $modList that has a matching "*.zip" within the TRIBES/mods directory will have that *.zip file loaded here
// eg. the scripts.zip in TRIBES/GameData directory can be copied to "base.zip" within the TRIBES/mods directory and loaded as "base" mod from there
function Bootstrap::loadModVolumes()
{
    if(String::Empty($modList) && $BaseServerType)
    {
        $modList = "base";
        $modCount++;
    }

    // Load mod volumes in the order they were declared
    for(%i = $modCount - 1; %i >= 0; %i--)
    {
        %word = getWord($modList, %i);
        %vol = %word @ ".zip";
        echo(sprintf("Searching for mod volume: %1.", %vol));
        if(isFile(sprintf("mods/%1", %vol)))
        {
            newObject(%word @ "Volume", SimVolume, %vol);
            echo(sprintf("%1.zip mod volume loaded.", %word));
        }
    }
}

function Bootstrap::execModScripts()
{
    // Exec mod scripts in the order they were declared
    for(%i = $modCount - 1; %i >= 0; %i--)
    {
        %word = getWord($modList, %i);
        %script = %word @ ".cs";
        echo(sprintf("Searching for mod script: %1.", %script));
        if(isFile(sprintf("config/Server/%1", %script)))
            exec(sprintf("Server/%1", %script));

        // if(isFile(getWord($modList, %i) @ ".cs"))
        //     exec(getWord($modList, %i) @ ".cs");
    }
}


// test if this is a dedicated server
$dedicated = false;

$numExecFiles = 0;

for(%i = 1; $cargv[%i] != ""; %i++)
{
    if($cargv[%i] == "-mod")
    {
        %mod = $cargv[%i + 1];
        %i++;
        Bootstrap::addMod( %mod );
    }
    else if($cargv[%i] == "-dedicated")
    {
        $dedicated = true;
        %mission = $cargv[%i + 1];
        if(%mission != "")
        {
            $HostMission = %mission;
            %i++;
        }
    }
    else if($cargv[%i] == "+exec")
    {
        $execFile[$numExecFiles] = $cargv[%i+1];
        %i++;
        $numExecFiles++;
    }
    else if($cargv[%i] == "+connect")
    {
        $connectAddress = $cargv[%i+1];
        %i++;
    }
    else if($cargv[%i] == "+password")
    {
        $Server::JoinPassword = $cargv[%i+1];
        $Server::Password = $cargv[%i+1];
        %i++;
    }
    else if($cargv[%i] == "+record")
    {
        setupRecorderFile();
    }
    else if($cargv[%i] == "-host")
    {
        $HostMission = $cargv[%i+1];
        $HostingGame = true;
        %i++;
    }
    else if($cargv[%i] == "+maxplayers")
    {
        $HostPlayerCount = $cargv[%i+1];
        %i++;
    }
    else if($cargv[%i] == "-edit")
    {
        $EditingMission = true;
        $EditMission = $cargv[%i+1];
        %i++;
    }

    // added in custom arguments to launch Tribes in either full screen or windowed mode based on startup target
    else if($cargv[%i] == "+fullscreen")
    {
        $StartupScreenMode = "Full Screen";
    }
    else if($cargv[%i] == "-fullscreen")
    {
        $StartupScreenMode = "Windowed";
    }
}

$WinConsoleEnabled = $dedicated;
$Console::logBufferEnabled = !$dedicated; // turn off window scroll back
$Console::Prompt = "% ";

if($dedicated)
{
    newServer();
    focusServer();
}
else
{
    newClient();
    focusClient();
    $Console::LastLineTimeout = 0;
}

//
Bootstrap::evalSearchPath();
newObject(FontsVolume, SimVolume, "fonts.zip");
newObject(ScriptsVolume, SimVolume, "scripts.zip"); // added "scripts" directory files in GameData to a new "scripts.zip" volume
newObject(GuiVolume, SimVolume, "gui.zip"); // added "gui" directory files in GameData to a new "gui.zip" volume
newObject(EditVolume, SimVolume, "edit.zip");
newObject(EditorVolume, SimVolume, "editor.zip");
newObject(InterfaceVolume, SimVolume, "Interface.zip");
newObject(ShellVolume, SimVolume, "Shell.zip");
newObject(ShellCommonVolume, SimVolume, "ShellCommon.zip");
newObject(EntitiesVolume, SimVolume, "Entities.zip");
newObject(Entities2Volume, SimVolume, "Entities2.zip"); // added "Entities" directory files in GameData to a new "Entities2.zip" volume
newObject(HUDsVolume, SimVolume, "huds.zip"); // added "huds" directory files in GameData to a new "huds.zip" volume

Bootstrap::loadModVolumes();

$Console::GFXFont = "interface.pft";

////
// Default volumes and tags
//

exec("common");
exec("client/loadall");
exec("sound/sfx.strings");
exec("banlist");
exec("server/missionlist");
exec("gui/gui");
exec("server/server");
exec("GenericTriggers");
exec("server/game/observer");
exec("gui/PlayerSetup");
exec("players");

Bootstrap::execModScripts();

exec("gui/Options");
exec("gui/commander");

Bootstrap::execModScripts();

//
// Default keys
//
bind(keyboard, make, control, o, to, "messageCanvasDevice(MainWindow, outline);");
bind(keyboard, make, sysreq, to, "screenShot(MainWindow);");
bind(keyboard, make, control, "-", to, "prevRes(MainWindow);");
bind(keyboard, make, control, "+",  to, "nextRes(MainWindow);");


// Load prefs and execute any autoexec commands...
exec("Server/serverDefaults");
exec("Server/serverPrefs");
exec("defaultClientPrefs");
exec("defaultConfig");
exec("clientPrefs");
exec("config");
exec("badwords");
if ( !$dedicated )
    exec("autoexec");

for(%i = 0; %i < $numExecFiles; %i++)
    exec($execFile[%i]);

// applying full screen or window mode setting taken from launch target line
if(!String::Empty($StartupScreenMode))
{
    if($StartupScreenMode == "Full Screen")
        $pref::VideoFullScreen = "TRUE";
    else if($StartupScreenMode == "Windowed")
        $pref::VideoFullScreen = "FALSE";
}

if($dedicated)
{
    if ($modCount && $MODInfo == "")
        $MODInfo = "This server is running the following mods: " @ $modList;

    if($HostPlayerCount > 0)
        $Server::MaxPlayers = $HostPlayerCount;
    createServer($HostMission, True);
    translateMasters();
    echo("Dedicated Server Initialized");
}
else
{
    newObject(ConsoleScheduler, SimConsoleScheduler);

    // Create the main window with a gui in it
    newObject(MainWindow, SimGui::Canvas, "Tribes", 800, 600, True, "800 600", "2560 1600");

    exec("sound/sound");
    inputActivate(keyboard0);
    inputActivate(mouse0);

    if($pref::noIpx)
        newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "LOOPBACK", 0);
    else
        newObject(clientDelegate, FearCSDelegate, false, "IP", 0, "IPX", 0, "LOOPBACK", 0);
    if(!$pref::lanOnly)
        translateMasters();

    // Action map for flying cameras
    exec("client/editor/move");
    move();

    setCursor(MainWindow, "Cur_Empty.bmp");
    cursorOn(MainWindow);
    GuiLoadContentCtrl(MainWindow, "gui/empty.gui");

    // GDCHACK : don't go fullscreen on startup (currently borked in webpage) 
    // $pref::VideoFullScreen = "FALSE";

    //all video initialization is now done in Options
    OptionsVideo::validate();
    OptionsVideo::apply();

    if($HostingGame)
    {
        setCursor(MainWindow, "Cur_Arrow.bmp");
        cursorOn(MainWindow);
        if($HostPlayerCount > 0)
            $Server::MaxPlayers = $HostPlayerCount;
        createServer($HostMission, false);
        $quitOnDisconnect = true;
    }
    else if($connectAddress != "")
    {
        $Server::Address = $connectAddress;
        setCursor(MainWindow, "Cur_Arrow.bmp");
        cursorOn(MainWindow);
        JoinGame();
        $quitOnDisconnect = true;
    }
    else if($EditingMission)
    {
        setCursor(MainWindow, "Cur_Arrow.bmp");
        cursorOn(MainWindow);
        if($HostPlayerCount > 0)
            $Server::MaxPlayers = $HostPlayerCount;
        exec("editor/editor");

        // check if creating or not
        %missionFile = "missions/" @ $EditMission @ ".mis";
        if(File::FindFirst(%missionFile) == "")
        {
            GuiLoadContentCtrl(MainWindow, "gui/mainmenu.gui");
            $NewMissionName = $EditMission;
            exec("editor/newmission");
        }
        else
            createServer($EditMission, false);
        $quitOnDisconnect = false;
    }
    else
    {
        //translate all master server addressess - this function will eventually call startTheGame()
        if($pref::quickstart)
        {
            GuiLoadContentCtrl(MainWindow, "gui/mainmenu.gui");
            Quickstart();
            translateMasters();
        }
        else
        {
            startMainMenuScreen();
        }
    }
    echo("Client Initialized");
}