# Tribes-1.41-Server
Tribes 1.41 slightly modified for easier server setup.

## Purpose
This is a copy of the "Original" Tribes 1.41 setup as patched and distributed originally by Plasmatic, which is also available in nearly an unedited version in [the Tribes files repo](https://github.com/shaykbake/Tribes/blob/main/Installations/1.41/Tribes%201.41%20Original%20by%20Plasmatic.7z).

What I've done is cleaned up and organized it a little bit. Plus, I've made some edits to `console.cs` that I feel make it run the game a little better for anyone planning to expand it with custom maps and mods. Essentially, a server setup.

### "base" Directory
The `base` directory has been renamed to `GameData`, and all but the `missions` and `voices` sub-directories within it have been compiled into respective `*.zip` files.

### "base" Mod Changes
The `base` mod that was distributed with 1.40/1.41 originally is still intact as `GameData/scripts.zip`, but I've taken the files and modified them slightly in the `mods/base.zip`:
* to restore the original item listing in inventory stations to match the order as they were in the 1.11 base mod
* to remove the "Announce Server Takeover" admin option that was never actually added into it
* to append a few stat changes during player kills/deaths/suicides to allow Deathmatch maps to be playable
* to correct the player auth flags for the "Enable Pickup Mode" admin option so that it is available and usable now

This isn't meant to be an actual "modification" of the game, so I tried to keep it to just essential things. If you want to use this to make your own mod, you can simply extract `base.zip` into a `TRIBES/mods/%modName%/scripts` directory of your choice and have at it.

The Balanced, DOX, LT and OpenCall maps that have been included with these versions of Tribes are all still here, but they have been moved to a `TRIBES/maps` sub-directory. Each map type added is configured in the `$ExtendedMaps` variable at the top of the `console.cs` file. If you wish to add more maps, you can create a new sub-directory within `TRIBES/maps` with its own `missions` sub-directory within it and add it to the array at the end of the variable. Otherwise, you can simply throw maps into the existing `TRIBES/maps/missions` sub-directory and they should be included without any necessary changes.

### Batch Files / InfiniteSpawn
I've also included a few batch files that can be used to quickly launch Tribes with whatever mod and server configuration file you wish to use. Since this is a server setup, I've included `InfiniteSpawn.exe` from the original Tribes game, since it was missing in 1.40/1.41 versions that are distributed around the net. The `Tribes - Load Mod Dedicated.bat` file will run Tribes with InfiniteSpawn.

The `Tribes - Load Mod Listen Windowed.bat` batch file will launch a prompt similar to the `Tribes - Load Mod Dedicated.bat` file, but will use your inputs to just launch `Tribes.exe` with whatever mod and server config you specified (aka a listen server).

The `Tribes - Play Windowed.bat` batch file will run `Tribes.exe` without any mod options but will also attach the `-fullscreen` startup argument to start the game in windowed mode. If you simply run `Tribes.exe` directly, it will start in whatever mode (windowed or full screen) that it was in when you last closed it.

## Discussions / Support
If you have any issues, suggestions or corrections that you find should be made, you can reach out in the [Discussions](https://github.com/shaykbake/Tribes-1.41-Server/discussions) for this repo, at the [{LS} forums](https://longshots.mk0.pw/forums/), or at the [{LS} Discord](https://longshots.mk0.pw/discord/).
