NewActionMap("actionMap.sae");
bindAction(keyboard0, make, "tab", TO, IDACTION_MENU_PAGE, 1);
bindAction(keyboard0, make, "escape", TO, IDACTION_ESCAPE_PRESSED, 0);
bindAction(keyboard0, make, "k", TO, IDACTION_MENU_PAGE, 2);
bindAction(keyboard0, make, "t", TO, IDACTION_CHAT, 0);
bindAction(keyboard0, make, "y", TO, IDACTION_CHAT, 1);
bindAction(keyboard0, make, "u", TO, IDACTION_CHAT_DISP_SIZE, -1);
bindAction(keyboard0, make, "prior", TO, IDACTION_CHAT_DISP_PAGE, -1);
bindAction(keyboard0, make, "next", TO, IDACTION_CHAT_DISP_PAGE, 1);
bindCommand(keyboard0, make, "o", TO, "remoteEval(2048, ToggleObjectivesMode);");
bindCommand(keyboard0, make, "i", TO, "remoteEval(2048, ToggleInventoryMode);");
bindCommand(keyboard0, make, "c", TO, "remoteEval(2048, ToggleCommandMode);");
bindCommand(keyboard0, make, control, "x", TO, "commandAck();");
bindCommand(keyboard0, make, control, "d", TO, "commandDeclined();");
bindCommand(keyboard0, make, control, "c", TO, "commandCompleted();");
bindCommand(keyboard0, make, control, "y", TO, "voteYes();");
bindCommand(keyboard0, make, control, "n", TO, "voteNo();");
bindCommand(keyboard0, make, control, "e", TO, "targetClient();");
bindCommand(keyboard0, make, l_alt, "s", TO, "StatHUD::Show();");
bindCommand(keyboard0, break, l_alt, "s", TO, "StatHUD::Hide();");
bindCommand(keyboard0, make, "f1", TO, "AutoBuy::SelectAndBuyLoadout(1);");
bindCommand(keyboard0, make, "f2", TO, "AutoBuy::SelectAndBuyLoadout(2);");
bindCommand(keyboard0, make, "f3", TO, "AutoBuy::SelectAndBuyLoadout(3);");
bindCommand(keyboard0, make, "f4", TO, "AutoBuy::SelectAndBuyLoadout(4);");
bindCommand(keyboard0, make, "f5", TO, "AutoBuy::SelectAndBuyLoadout(5);");
NewActionMap("playMap.sae");
bindAction(mouse0, xaxis0, TO, IDACTION_YAW, Flip, Scale, 0.000999);
bindAction(mouse0, yaxis0, TO, IDACTION_PITCH, Flip, Scale, 0.000999);
bindAction(keyboard0, make, "a", TO, IDACTION_MOVELEFT, 1);
bindAction(keyboard0, break, "a", TO, IDACTION_MOVELEFT, 0);
bindAction(keyboard0, make, "d", TO, IDACTION_MOVERIGHT, 1);
bindAction(keyboard0, break, "d", TO, IDACTION_MOVERIGHT, 0);
bindAction(keyboard0, make, "s", TO, IDACTION_MOVEBACK, 1);
bindAction(keyboard0, break, "s", TO, IDACTION_MOVEBACK, 0);
bindAction(keyboard0, make, "w", TO, IDACTION_MOVEFORWARD, 1);
bindAction(keyboard0, break, "w", TO, IDACTION_MOVEFORWARD, 0);
bindAction(mouse0, make, button1, TO, IDACTION_JET, 1);
bindAction(mouse0, break, button1, TO, IDACTION_JET, 0);
bindAction(mouse0, make, button0, TO, IDACTION_FIRE1);
bindAction(mouse0, break, button0, TO, IDACTION_BREAK1);
bindAction(keyboard0, make, "x", TO, IDACTION_CROUCH);
bindAction(keyboard0, break, "x", TO, IDACTION_STAND);
bindAction(keyboard0, make, "r", TO, IDACTION_VIEW);
bindAction(keyboard0, make, "space", TO, IDACTION_MOVEUP, 1);
bindAction(keyboard0, break, "space", TO, IDACTION_MOVEUP, 0);
bindCommand(keyboard0, make, "e", TO, "Zoom::In();");
bindCommand(keyboard0, break, "e", TO, "Zoom::Out();");
bindCommand(keyboard0, make, "z", TO, "Zoom::Cycle();");
bindCommand(keyboard0, make, "v", TO, "setCMMode(PlayChatMenu, 2);");
bindCommand(keyboard0, make, "b", TO, "use(\"Beacon\");");
bindCommand(keyboard0, make, "m", TO, "throwStart();");
bindCommand(keyboard0, break, "m", TO, "throwRelease(\"Mine\");");
bindCommand(keyboard0, make, "g", TO, "throwStart();");
bindCommand(keyboard0, break, "g", TO, "throwRelease(\"Grenade\");");
bindCommand(keyboard0, make, "1", TO, "use(\"Blaster\");");
bindCommand(keyboard0, make, "2", TO, "use(\"Plasma Gun\");");
bindCommand(keyboard0, make, "3", TO, "use(\"Chaingun\");");
bindCommand(keyboard0, make, "4", TO, "use(\"Disc Launcher\");");
bindCommand(keyboard0, make, "5", TO, "use(\"Grenade Launcher\");");
bindCommand(keyboard0, make, "6", TO, "use(\"Laser Rifle\");");
bindCommand(keyboard0, make, "7", TO, "use(\"ELF gun\");");
bindCommand(keyboard0, make, "8", TO, "use(\"Mortar\");");
bindCommand(keyboard0, make, "9", TO, "use(\"Targeting Laser\");");
bindAction(keyboard0, make, "numpad8", TO, IDACTION_LOOKUP, 0.099999);
bindAction(keyboard0, break, "numpad8", TO, IDACTION_LOOKUP, 0);
bindAction(keyboard0, make, "numpad2", TO, IDACTION_LOOKDOWN, 0.099999);
bindAction(keyboard0, break, "numpad2", TO, IDACTION_LOOKDOWN, 0);
bindAction(keyboard0, make, "numpad6", TO, IDACTION_TURNRIGHT, 0.099999);
bindAction(keyboard0, break, "numpad6", TO, IDACTION_TURNRIGHT, 0);
bindAction(keyboard0, make, "numpad4", TO, IDACTION_TURNLEFT, 0.099999);
bindAction(keyboard0, break, "numpad4", TO, IDACTION_TURNLEFT, 0);
bindAction(keyboard0, make, "numpad5", TO, IDACTION_CENTERVIEW);
bindCommand(keyboard0, make, "h", TO, "use(\"Repair Kit\");");
bindCommand(keyboard0, make, "p", TO, "use(\"BackPack\");");
bindCommand(keyboard0, make, control, "p", TO, "drop(BackPack);");
bindCommand(keyboard0, make, control, "w", TO, "drop(Weapon);");
bindCommand(keyboard0, make, control, "a", TO, "drop(Ammo);");
bindCommand(keyboard0, make, control, "f", TO, "drop(Flag);");
bindCommand(keyboard0, make, control, "k", TO, "kill();");
bindCommand(mouse0, make, zaxis1, TO, "nextWeapon();");
bindCommand(mouse0, make, zaxis0, TO, "prevWeapon();");
bindCommand(keyboard0, make, "f6", TO, "TV::Activate($TV::Carrier);");
bindCommand(keyboard0, break, "f6", TO, "TV::DeActivate();");
bindCommand(keyboard0, make, "q", TO, "nextWeapon();");
NewActionMap("pdaMap.sae");
bindAction(keyboard0, make, "z", TO, IDACTION_ZOOM_MODE_ON);
bindAction(keyboard0, break, "z", TO, IDACTION_ZOOM_MODE_OFF);
NewActionMap("inventoryMap.sae");
bindCommand(keyboard0, make, "2", TO, "AutoBuy::litterItem( \"Repair Pack\" );");
bindCommand(keyboard0, make, "1", TO, "AutoBuy::litterItem( \"Turret\" );");
bindCommand(keyboard0, make, "4", TO, "AutoBuy::litterItem( \"Pulse Sensor\" );");
bindCommand(keyboard0, make, "3", TO, "AutoBuy::litterItem( \"Inventory Station\" );");
NewActionMap("demoMap.sae");
bindCommand(keyboard0, make, "up", TO, "Demo::SpeedControl(\"normal\");");
bindCommand(keyboard0, make, "down", TO, "Demo::SpeedControl(\"pause\");");
bindCommand(keyboard0, make, "left", TO, "Demo::SpeedControl(\"sd\");");
bindCommand(keyboard0, make, "right", TO, "Demo::SpeedControl(\"ff\");");
