@echo off
set modHeader=T R I B E S  S E R V E R
set modName=TRIBES Client/Listen Server Launcher
set modAuthor=Shayk-N'-Bake
set modWebsite=https://github.com/shaykbake
set exeName=Tribes.exe
set year=2010

title %modName% (By %modAuthor%)
set acolor=0
set text=c
color 0b

:start
echo.
echo  %modHeader%
echo.
echo  (C)Copyright %modAuthor% %year%.
echo.
echo  %modWebsite%
IF NOT EXIST Tribes.exe goto noTribes
IF NOT EXIST InfiniteSpawn.exe goto noInfiniteSpawn
ECHO.


:getServerMod
echo.
ECHO Type name of server mod with data files in TRIBES/mods directory.
echo.

:setServerMod
set ServerMod=
set /p ServerMod=-mod: 

IF DEFINED ServerMod (
    set ServerMod=-mod %ServerMod%
    )


:getServerConfig
echo.
ECHO Type name of server config file located in TRIBES/config/Server directory.
echo.

:setServerConfig
set ServerConfig=
set /p ServerConfig=+exec: 

IF DEFINED ServerConfig (
    set ServerConfig=+exec %ServerConfig%
    )


:run
echo Starting %ServerMod% ...
ping 1.1.1.1 -n 1 -w 2000 > nul
START %exeName% +exec %ServerConfig% -mod %ServerMod% -fullscreen
goto end

:runBase
echo Starting 1.41 Vanilla ...
ping 1.1.1.1 -n 1 -w 2000 > nul
START %exeName% +exec %modConfig% -fullscreen
goto end

:site
start %modWebsite%
goto choice

:goodbye
echo.
echo Peace out, homie...
ping 1.1.1.1 -n 1 -w 1000 > nul
goto end

:noTribes
echo.
echo Missing Tribes.exe
echo Please make sure this bat file is in your main Tribes directory where Tribes.exe is located.
pause

:noInfiniteSpawn
echo.
echo Missing InfiniteSpawn.exe
echo Please make sure this bat file is in your main Tribes directory where InfiniteSpawn.exe is located.
pause

:end
