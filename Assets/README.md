# Assets

# Player
Les composantes qui gèrent les déplacements du personnage se trouvent dans le dossier carater dans le script CMove.<br />
Il contient aussi les conditions pour changer les animations lors des déplacements.

# Vie
Pour la gestion de la vie du personnage, toutes les informations sont dans le script HealthDisplay.<br />
Le script qui est responsable de rendre de la vie au personnage lors qu'il interagit avec un lit par exemple se nomme Restore.

# Sort
Le personnage possède en commençant la possibilité de faire une attaque au corps-à-corps qui est dans le script Slash.<br />
Le script MagicDisplay permet au joueur de changer de sort quand il en possède un autre et de définir la direction appropriée pour son sort.<br />
Quand le joueur change de sort, il change l'objet ClassSort. le script s'appelle ClassSort.<br />
Il y a le script fireball qui est un exemple de sort que le personnage peut récupérer.

# Monster
Les monstres possèdent un script qui gère leurs points de vie et les objets qu'ils laissent tomber.<br />
Les monstres laissent tomber 1 des 3 objets prédéfinis qui possèdent un script loot pour gérer les statistiques de l'objet.<br />
Chaque monstre possède une petite barre de vie qui indique au joueur les restants des points de vie du monstre.<br />
Le script LifeMiniBar gère le concept.<br />
Les monstres apparaissent et disparaissent quand le joueur change d'endroit à l'aide du script OutPlace.<br />
L'apparition et la disparition des monstres sont gérées par les scripts Respawn et Despawn

# Équipement
L'équipment du joueur est géré par les scripts équipement et Inventory.<br /> 
Inventory contient tous les éléments que le joueur possède dans son sac tandis que Équipement gère les objets équipés et les éléments qui composent le menu d'inventaire du joueur.

# Shop
Le script Shop permet l'accès au magasin de la taverne pour vider son inventaire en échange de pièces.<br />
La fonction permettant de vendre et de faire dérouler le menu dans le magasin se trouve dans le script ShopScroll.

# Interaction
Il y a des scripts qui permettent l'interaction avec certains éléments comme ActionBut et ActionDoorAnd.<br />
Il y a aussi le script Down qui est spécifique à un NPC et qui possède certaines actions selon l'état de l'animation du joueur.
