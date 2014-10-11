EcoSystem
=====
Look at this file wih the notepad ! Should be way more readable !

©
Feltz Ludovic, 
Genoud Mathieu

Including free assets from : 

http://unity3d.com/
http://rivaltheory.com/rain/
https://www.facebook.com/pages/Laali-Unit/257947474377347
http://www.jpneufeld.com/
http://www.profidevelopers.com/
http://electrodynamicsproductions.blogspot.ca/

Software versions : 
Unity 4.6		http://unity3d.com/unity/beta/4.6
Blender 2.71		http://www.blender.org/download/
The Gimp 2.8		http://www.gimp.org/downloads/
Photoshop Elements 8.0 (Licensed version)
Rain 2.1		http://rivaltheory.com/rain/download/ (also availlable in Unity's Assets Store)

SEE : ScreenShot.bmp (can be improved)
SEE : Game design project for first public build below

TODO: 

Development : 

-A fighting system
	-Developping AIs (using Rain or not)
		- Animals have 2 classes : Wild and Tame
		- Exept for the tame snake, wich attacks and then flees, tame animals only flee on sight/damage receive
		- You can be creative on the behaviors you want to create, but they must be accurate with their 				   animations
	-Developping the player's fighting system
		-Adding an "attack" button wich runs hit2.cs
		-Creating a real-time rpg-like combat system with XP, damages and life for both animals and player
		(see the game design proposition below)

-The environment control
	-the environmental visual feedback can be improved
	-the "flore" visual feedback needs to be done or adaptated (see : EnvironmentControl.cs)

-Spawning system
	-Developping it ! The spawning system should be : 
		-zoned (for it to load when the player crosses some triggers)
		-determined by Ecosystem values for types and wilderness
- (to be continued)


Graphics :

(see root folder/Models - WIP/*.blend  - Look into the layers and find three animals type : Layer 1 is Wild, 2 is Neutral, 3 is Tame. At the moment we do not use a "neutral" class, so "Tame Fish" is the "Neutral Fish", "Tame Bug" is the "Tame Bug", "Tame Snake" is the "Neutral Snake" and the Mammals needs to be modelled
see the mess with my textures in >Root folder/Models - WIP/Textures - WIP and hires/*.XCF, *.PSD, *.PNG, *.TIF and *.JPG)

-Modelling
	-Tame and Wild Mammal
	-High polygons for texturing
		-Tame Mammal
		-Wild Mammal
		-Tame Bug
		-Wild Bug
		-Tame Snake

-Texturing
	-Normal maps
		-Tame Snake
		-Tame Bug
		-Wild Bug
		-Tame Mammal
		-Wild Mammal
	
	-Color maps
		-Tame Snake
		-Tame Bug
		-Wild Bug
		-Tame Mammal
		-Wild Mammal

-Animating
	-Review Wild Snake's animation
	-Tame Snake
	-Tame Bug (erratic, "vibrates" when fears)
	-Wild bug (spider)
	-Tame Mammal
	-Wild Mammal


Game Design Project for first "really public" build :

/* This part is still in French
Nomenclature : 
Type = Poisson, Reptile, Insecte, Mammifère
Force = Puissance Attaque
SpawnNbrTotal = Nombre total d'animaux à faire spawner
TauxSpawn = Répartition de SpawnNbrTotal dans chaque type selon Ecosystème
lvlPlayer = Progression à définir
Note : Tous les animaux présents sur la map telle que décrite ci-après n'ont pas forcément de Spawn, certains sont définis (comme le serpent de PeakView qui reste seul)

On va donc ajouter une "proto-mecanique" de la faune dans ce jeu d'aventure. Dans chaque zone (j'en ai défini 12 sur la partie de la map déjà faite) le joueur sera face à un choix à faire (plus ou moins explicite) et ces choix lui feront ou non tuer les animaux qu'il croise, provoquant un impact sur l'ecosystème qui lui-même impactera certaines variables des ennemis( ex : nbr Spawn, Force, ... genre de détails sur lesquels ils nous faudra de nouvelles mises au points "en live"). Me dit pas tout de suite : "mais ca va être trop la merde les IA et tout" (c'est pas productif merde :p ), ça je m'en charge, lis juste mon concept et dis moi si tu approuve l'idée en général.
*/

This is how I Zoned our map on paper (seel also ScreenShot.bmp), and here there's the choices that the player encounters.


Beach 					  ----    Killing tame fishes ->  ecosystem variation
  |
PeakView 				  ----  A tame snake kills one or more tame bugs -> ecosystem variation
  |		|				Player kills the snake and/or bugs -> ecosystem variation
  |             |
  |      (Passage of the Damned)	  ---- Shortway to Hope Crest, where the playe encounters 
  |						an enemy(type=random and ecosystem) too strong for low-level player
  |						(but not impossible)
  |
Willows				  	  ----  Going by the bridge and being detected by wild Mammal or
  |             |				going by the lake and being attacked by wild Fishes 
  |		|				-> kiling fishes -> ecosystem variation
  |	      	|
  |	       Lake  			  ---- Useful for avoiding the Mammal detection (not exclusive) 
Pont		|				but being attacked by fishes. Kiling fishes -> Ecosystem variation
  |		|
       Maze     			  ---- if previously detected : Wild Mammals embush.
        |					 killing mammals -> ecosystem variation
	|
     Snakes  				  ---- Wild Snakes attacks from within the grass 
	|					Attacks player that make a close encounter.
	|					-> Killing Snakes -> ecosystem variation
	|					
  Forest Passage  			  ---- Where the Static Batching lacks  -- awaiting more AI developments,
	|					 Animals here should have a more natural behavior. 
						Killing them -> ecosystem variation
	|
   Hope Crest  			  	  ----- Enemy-free zone before "middleway challenge" 
	|					2 ways to come from : "Passage of the damned" or "Forest Passage")
	|
  "middleway challenge" 		  ----- A "Final Boss" (determined by LVL player and Ecosystem, should be strong)
	|
   Secret way to the Peak where a bonus life awaits the player.