EcoSystem
=====

©
Feltz Ludovic, 
Genoud Mathieu


TODO: Mettre les idées ici !


TALK:

		--------

MattGen : Je-viens-de-voir-cette-update-jai-fait-quelques-modifs-aprs-fais-gaffe-aux-conflits-si-tu-bosses-la.tu-peux-garder-ma-modif-du-terrain-c'est-juste-un-ajustement-des-textures-qui-bugaient-sur-le-droide.Jai-ajouté-mes-icones-sur-le-slider,-delocké-l'environnement,-desactivé-le-script-hit.cs-et-changé-ma-texture-de-flotte-qui-bugait-sur-android.Toujours-pas-de-clavier-propre,-je-fais-un-joli-TODO-demain.

		--------

ludo6577 : ok comme tu peut le voir je suit toujours les updates ! si jamais tu fais des modifs je le verrai tkt

		--------

MattGen : Bon va falloir que je me fasse à Tortoise... J'ai pas fait de connerie là ?

Bon, le topo, un ToDo propre attendra encore un peu. 
On a donc un monde défini et une mécanique de base que l'on va exploiter sommairement dans un micro-jeu d'aventure. On est d'accord ?

Disons que oui : 

Nomenclature : 
Type = Poisson, Reptile, Insecte, Mammifère
Force = Puissance Attaque
SpawnNbrTotal = Nombre total d'animaux à faire spawner
TauxSpawn = Répartition de SpawnNbrTotal dans chaque type selon Ecosystème
lvlPlayer = Progression à définir
Note : Tous les animaux présents sur la map telle que décrite ci-après n'ont pas forcément de Spawn, certains sont définis (comme le serpent de PeakView qui reste seul)

On va donc ajouter une "proto-mecanique" de la faune dans ce jeu d'aventure. Dans chaque zone (j'en ai défini 12 sur la partie de la map déjà faite) le joueur sera face à un choix à faire (plus ou moins explicite) et ces choix lui feront ou non tuer les animaux qu'il croise, provoquant un impact sur l'ecosystème qui lui-même impactera certaines variables des ennemis( ex : nbr Spawn, Force, ... genre de détails sur lesquels ils nous faudra de nouvelles mises au points "en live"). Me dit pas tout de suite : "mais ca va être trop la merde les IA et tout" (c'est pas productif merde :p ), ça je m'en charge, lis juste mon concept et dis moi si tu approuve l'idée en général.

Voici comment j'ai "zoné" sur papier notre map, avec en bonus les choix qui s'y déroulent.
Voir ScreenShot.bmp pour mieux associer ma map en txt à la map réelle.

Plage  					  ----    Buter d'innofensifs poissons -> Impact ecosysteme
  |
PeakView(la plaine juste après la plage)  ----  Un serpent butte un ou des insectes -> Impact ecosysteme
  |		|				Le joueur butte le serpent et/ou les insectes -> Impact ecosysteme
  |             |
  |      Passage des Bannis 		  ---- Raccourci vers crête espoir, après un ennemi(type=random et ecosystem) 
  |						trop fort pour les bas lvl (mais pas impossible)
  |
Saules(là où il y a des saules)  	  ----  Passer par le pont et détection par mammifère ou  
  |             |				le lac et aggro par des poissons -> buter des poissons = impact ecosysteme
  |	      	|
  |	       Lac  			  ---- Permet d'éviter détection mammifère (pas exclusif) 
Pont		|				mais aggro par des poissons. Buter poissons -> impact ecosysteme
  |		|
    Labyrinthe     			  ---- Si Précedemment détecté : embuscade par des mammifères.
        |					 buter mammifère -> impact ecosysteme
	|
     Serpents  				  ---- Des serpents trainent dans hautes herbes et 
	|					attaquent Player qui s'en approche. Buter serpents -> impact ecosysteme
	|
  Passe Forestière  			  ---- La zone qui rame à mort  -- ici bordel d'animaux,
	|					 en attendant de bien gérer les IA ils seront tous innofensifs. En buter -> Impact Ecosysteme
	|
   Crête de l'espoir  			  ----- Le calme avant "Defi Interm." Arrivée depuis Passe Forestière ou Passage des Bannis
	|
  "Defi interm." 			  ----- Un "Boss de fin" au pied du pic dont le type est défini par ecosysteme et la force par lvlPlayer
	|
   Passage secret vers le Pic ou attend une vie bonus


Avec ça on devrait avoir une version plutôt cool, et ça laisse de quoi bosser sur les IA pour un dévellopement futur ou d'autres projets (Rain c'est pas si difficile que tu le crois, faut juste apprendre à le dompter). On pourrait faire la suite en travaillant l'autre côté de l'île et arriver avec un jeu d'un peu plus d'une heure de jeu (pour le player qui comprend vite qu'il faut pas trop déconner avec l'ecosystème, les autres). 

Test pull request