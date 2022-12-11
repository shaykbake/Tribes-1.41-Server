// Client fixes for Tribes 1.40.655
// Collected by Plasmatic
// www.annihilation.info
// More information at http://www.tribalwar.com/forums/showthread.php?t=630310
// and http://www.annihilation.info/forum/viewtopic.php?f=1&t=8595

echo("+++++++++++++++++++++++  Loading 1.40.655 Service Pack 1.0");


//Master server
$Server::CurrentMaster = "0";$Server::MasterAddressN0 = "t1m1.tribes0.com:28000 t1m1.masters.tribesmasterserver.com:28000 t1m1.pu.net:28000 skbmaster.ath.cx:28000 kigen.ath.cx:28000 t1m1.masters.dynamix.com:28000";

// Video Lag fix.
$pref::screensize = 1;

//Flag hud fix - Hunden/ Greyhound
function remoteTeamScore( %sv, %team, %score ) {
	$Team::Score[%team] = %score;
}

//Hud position fix - Hunden/ Greyhound
$HudMessupFix::DoExport = false;
function HudMessupFix::OnGuiOpen( %gui ) after Hud::OnGuiOpen {
	if ( %gui == "playGui" )
		$HudMessupFix::DoExport = true;
}
function HudMessupFix::OnExit() before Hud::OnExit 
{
	if($HudMessupFix::DoExport) //fine, don't halt
		return;	
	echo("Sucky behavior detected and prevented.");
	halt;
}

// Not really necessary, but nice changes to make:
// $pref::playerfov = 110; 	// Default 90. Increases field of view to compensate for wide screen monitors.
$pref:terrainlodamount = 0; 	// Default is 1. Decreases terrain warping at the expense of fps.

$pref::OpenGL::useMultiTexturing = "True"; 	// Increases fps on some cards.
$pref::OpenGL::flushAfterPasses = "False"; 	// Increases fps on some cards.

EditActionMap("playMap.sae");
bindCommand(keyboard0, make, "q", TO, "nextWeapon();");