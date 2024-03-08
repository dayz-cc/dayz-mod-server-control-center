DayZ Server Controlcenter by Crosire
=============================================================

=======> Read this whole readme before you continue! <=======

1. Introduction:
----------------

Thanks for downloading my Server Controlcenter. Hours of work
went into this, so a thank you and some support would be
nice :) Enjoy!

Please read this carefully and only post your problems if the
troubleshooting section below isn't helping to fix it.


2. Requirements:
----------------

- .Net Framework 4
   http://www.microsoft.com/download/en/details.aspx?id=24872
- [Microsoft Visual C++ 2010 Redistributable Package (x86)]
   http://www.microsoft.com/en-us/download/details.aspx?id=5555
- [Microsoft Visual C++ 2012 Redistributable Package (x86)]
   http://www.microsoft.com/en-us/download/details.aspx?id=30679
- Adobe Flash Player
   http://get.adobe.com/flashplayer

- ArmA 2 Combined Operations
- Recommended Beta Patch
   http://www.arma2.com/beta-patch.php
- DayZ Mod
   http://dayzmod.com/?Download
   http://dayzcommander.com/

The "[...]" requirements can be installed right from the setup
wizard.


3. Installation:
----------------

If you have steam: Start ArmA 2 OA once with steam and quit
again (even if you can't play because of no VGA). Now copy the
"Addons" folder in your "ArmA 2" folder into your "ArmA 2
Operation Arrowhead" folder to have Combined Operations.
Start Combined Operations through Steam at least one time again
for the keys to generate!

Make sure no previous server package is installed (better
start fresh). Start the setup wizard and follow the instructions
on screen, if you already have a MySQL server running, don't
forget to enter its login details! After installation you are
ready to run the Controlcenter. Please read the next paragraph
for more detailed information on how to use it before posting any
topics on the web and do not forget to change default passwords!
Applications like Virtual Box can mess up your IP configuration,
it is not recommended to have them installed.


4. The Controlcenter:
---------------------

These three options are available after installation:

- "Configuration"
   Change everything. Name, password, timezone or enable the
   build-in whitelist...
- "Administration"
   Easy to use web frontend, realtime log monitor. Start and
   manage your server here.
- "Database"
   Using Chive you can edit all ingame data or backup, restore
   and reset your whole database.
- "Information"
   Change the application language.

Database:
To start editing wait until Chive has connected to MySQL
sucessfully, login using default MySQL information and select
the dayz database you want to alter ("dayz_chernarus" for
example). Enter a table, click on "Browse" and edit the
contents to your likings.

- instance:
   Everything here can be configurated from the Controlcenter
- instance_vehicle:
   Contains all ingame vehicles.
- instance_deployable:
   Contains all ingame tents and sandbags.
- instance_building:
   Contains all extra buildings that are spawned on
   serverstartup.
- log_code:
   Description for log.
- log_entry:
   Server logging.
- log_tool:
   Action log from the admin tool.
- profile:
   Stores global player data.
- survivor:
   Data on the characters is saved here.
   To match the character to a player compare the unique_id
   with the profile table!
- vehicle, world_vehicle:
   All possible spawn locations for vehicles used by the
   vehicle generation script.
- building, world_building:
   Same like vehicles, just for buildings.
- users:
   Contains users from the admin tool, their hashed
   passwords and permissions.

Administration:
Wait until the login page is displayed and login using
default user and password found below (can be changed when
clicking on the "account" button).

- Dashbord:
   Overview of your server.
- Manage: Needs "manage", "control" and "whitelist" permissions
   Start and stop your server or start useful operations
   from an overview screen and manage the whitelist.
- Entitys & Info: Needs "table" permission
   Lists of ingame vehicles and characters. Select one
   to get detailed information about them with options to
   edit their inventory and more. Check for banned items
   to find hackers easily.
- Map: Needs "map" permission
   Display all players, vehicles and objects on a map of
   your current selected world.
- Feed: Needs "feed" permission
   Parses the logfiles to output a table of all kill
   activity on the server, only works when logging of
   kill messages is enabled.
- Tools: Needs "tools" permission
   Add vehicles and buildings to the database from a
   mission file you created in ArmAs 3D editor!

To logout again, press the button on the top right
corner.

If you want to add items to the banlist that will appear
on the item check page if a player has them, edit
"@dayzcc\htdocs\dayz\banned.txt", put the class names
in there with quotes around. Every item goes into a new line.


5. Default Passwords:
---------------------

(It is highly recommended to change these!)

- Admin Tool:
   Username: admin
   Password: adminpass (Edit the user in "Account" on the web interface)
- Chive/MySQL 1:
   Username: dayz
   Password: dayz (Change this on the local tab)
- Chive/MySQL 2:
   Username: root
   Password: (Found in the setup log)
- BattlEye Rcon:
   Password: adminpass (Change this on the configuration tab)


6. Troubleshooting:
-------------------

Problem:   MySQL Server/Apache won't start, they crash or do
           nothing.
Solution:  Update the server with "reconfigurate" option in
           the Set Up Wizard and make sure port 78, 3306 are
           not used by another application!

Problem:   Server does not appear in gamespy online server list.
Solution:  Open these ports: UDP 2300-2400, 47624-47624,
           28800-28900; TCP 2300-2400, 47624-47624 (in your
           router too) and make sure reporting Ip is set
           to "master.gamespy.com".

Problem:   Server still does not appear on DayZ Commander.
Solution:  DayZ Commander uses its own server database,
           it takes some time for them to recognize your
           server. Just leave it running for a couple of
           days and it should show up quickly. Make sure
           you include the DayZ version in the servername
           too, otherwise you might get blacklisted.

Problem:   Stuck at waiting for host and "Mission read
           from bank" spam in the server window.
Solution:  Make sure you have installed DayZ and Combined
           Operations (and the DayZ maps if enabled). It
           is recommended to use DayZ Commander to install
           and update! If you still experience the error, check
           the rpt log, it will tell you what is missing.

Problem:   MessageBox saying something like "php.exe - entry
           point not found. The procedure entry point
           php_checkuid could be located in the dynamic link
           library php5ts.dll" poping up on setup. Everything
           fails after that.
Solution:  You probably have PHP already installed. In most cases
           there is a entry in your PATH enviroment variable then
           which makes the included php to fail. Remove it from
           there and/or remove your installed PHP version if not
           needed.