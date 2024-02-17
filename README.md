# 3D-VEA-project-2022
Course project repository for 3D Virtual Environments and Applications 2022

## Introduction
Project is a small adventure game, which consists main menu scene, a quest hub scene and three 
different scenes for three different simple quests.

## Environment

Quest hub scene which is floating in the space is created by using cubes with default unity cubes (which 
do not have green emissive material on them) and cubes that are modelled in the blender (ones with 
the green emissive material). The scene also has a downloaded skybox cube to give the space look. 
Cubes are moving up and down based on their location related to the parent object to give a little bit of 
floating feeling. Since this is simple a scene just for the quest hub, this is modelled and scripted in unity. 
Lighting in the quest hub scene comes from the directional lighting and the space skybox. This scene 
does not contain the usage of terrain or landscape system. Other quest hub scene objects are simple 
portal frames, which are modelled in Blender, portal shaders, which are created by using shader graph 
tool in unity (by following tutorial), interactive NPC, who gives quests to the player character (both using 
the same mesh created in Blender) and big downloaded planet object, which is rotating (scripted) next 
to the big sphere with a highly emissive material. Around the sphere is a variation of the portal shader to 
give a little bit more movement to the sky. The scene also uses post-processing to make everything look 
a little bit better (bloom, colour grading, vignette, ambient occlusion). 

![level0](https://github.com/Myjoyysr/3D-VEA-project-2022/blob/main/img/level0.JPG)

Quest levels are using the same small terrain, which is created with the Unity terrain tool. Trees, grass 
and ground materials and meshes are downloaded from the Unity store. The scene has modified skybox 
and faint directional lighting source. Scenes contain simple fireplaces (modelled in Unity), which have 
emissive material with spotlights, which are pulsating slowly. Scenes also have particle systems, which 
are trying to imitate fireflies. Fireflies also have small point lights, which light up trees and the ground if 
they move close enough. The portal in this scene has two huge emissive pillars which also have two 
point lights next to them. The player object has faint directional light above him, which does not affect 
the player character layer, but when going near the trees or the dark spots in the scene, it lights up near 
objects a little bit. Other scene objects are low poly bananas which are modelled in Blender and have 
highly emissive material (they have also an albedo map, but it is not visible due to the emissive 
material). Level two has four non-interactive NPC characters idling next to the fireplaces (message 
interaction when the player goes too close). Level three has the same four enemy NPC characters, but 
this time they are more interactive. Also, these scenes have used a lot of post-processing (bloom, colour 
grading, vignette, ambient occlusion). Also, the small size of the terrain is compensated with fog. 

![level1](https://github.com/Myjoyysr/3D-VEA-project-2022/blob/main/img/level1.JPG)

## Player character

The player character is modelled, rigged and animated in the Blender. The game uses 3rd person 
controller with a character state machine and with the main camera and two Cinemachine cameras (one 
for following player and one for “strafe mode”/target locking). The character object has three different 
animations, idling, walking and running. Walking animation is used for interaction (NPC) and shooting 
(Player). 

![models](https://github.com/Myjoyysr/3D-VEA-project-2022/blob/main/img/models.JPG)

## Materials/shaders

The most interesting and complex material is material for the player character. It contains a normal 
map, albedo map and occlusion map which are created in Blender and secondary downloaded normal 
and albedo maps for a cloth-like look. Other materials are emissive or simple (like fire foods) or 
downloaded. 

Shaders were created with shader graph tool.

![shaders](https://github.com/Myjoyysr/3D-VEA-project-2022/blob/main/img/shaders.JPG)

## Animations

Animations for the player character (and NPCs) are made in Blender and they are based on multiple 
keyframes. Other moving objects in the game are scripted. 

![anim](https://github.com/Myjoyysr/3D-VEA-project-2022/blob/main/img/anim.JPG)

## NPCs

The game contains two different kinds of NPCs. Quest giver NPC and enemy NPC. They both have the 
same mesh as the player character, but their material is slightly modified to avoid confusion. They also 
have the same animations as the player character. Interaction over the game progression with friendly 
NPC is made with saved game states (saved in playerfabs). Friendly NPC animations are based on a 
simple state machine (idle or walking). Interaction is handled mostly with different kinds of collisions. 
Enemy NPC has a simple state machine which allows him to chase the player if the player goes too close 
to him and return to his guard point if needed. Enemy NPC uses navmesh for navigating during chasing 
the player or returning to his idle point.

## Interactions

The game has different kinds of interactions with the environment and the NPCs. For the interactions 
with the environment, the player is able to interact with portals and collect the bananas. Also, 
interactions with the environment are mostly guided by UI message. With quest giver NPC, the player is 
able to interact by being close to him (inside of interaction collider) and starting a conversation. NPC 
shows animation when interacting with. Enemy NPCs are interacted by shooting at them or not shooting 
and dying to collision with them. 

## Audio

For background sounds I decided to use simple background music instead for example forest sounds. 
With a lot of testing, I find out that it fits better to this kind of game. In level three is adaptive audio used 
when engaging with the enemies. These music clips are downloaded. Character makes running, firing 
and die sounds. These all are dependent on the character position compared to the camera position. 
Running sounds are downloaded but firing and die sounds are self-recorded many years ago. 


## Performance optimization

Character is modelled with sculpting and retopology and baking maps from the higher-resolution model. 
Other meshes are low poly. Terrain area is so small that hiding shadows based on the camera distance 
or other optimization methods were not really needed and affected the scene atmosphere highly. Code 
side escalated to be more complex than it should be in this scale of project, but focus was still to keep it 
optimized (not calling same things in different scripts in the updates). 