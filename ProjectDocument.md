# Wanted: Cyber Run

## Summary

**A paragraph-length pitch for your game.**

## Project Resources

[Web-playable version of your game.](https://itch.io/)  
[Trailor](https://youtube.com)  
[Press Kit](https://dopresskit.com/)  
[Proposal: Initial Plan](https://docs.google.com/document/d/1mTcej1XkV0b86fvPoavogw3iHswhOYx9IMi1iMxz6IA/edit?usp=sharing)  

## Gameplay Explanation

**Input**
`W` - Moves the Player up
`A` - Moves the Player to the left
`S` - Moves the Player down
`D` - Moves the Player to the right

`Mouse Cursor` - Aim Player weapon
`Left Mouse Click` - Fire Player weapon & select weapon upgrades

**The Objective**
The player must outlast the waves of different enemies and kill enough of them so that when they make their way to the *blue boat* on the docks at the bottom of the map, they have enough money to survive. If the player is not able to withstand the onslaught, upon death an upgrade shop becomes available for them to upgrade their only weapon and try again.

**Tips**
- Keep moving so that it is hard for the enemies to hit you
- Don't be scared of spending money on upgrades to make it to the end
- Keep firing at enemies to collect money and prevent too many from spawning
- Use your sprint at key moments in order to get out of danger and reposition
- Be aware of slower and faster enemies that may catch you off guard

# Main Roles

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least four such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The game's background consists of procedurally generated terrain produced with Perlin noise. The game can modify this terrain at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer - Lucas Nguyen
*Project Timeline* - Here is a [Gantt chart](./Materials/cyberrun_ganttchart.pdf) that depicts the timeline in which our project was completed.

*Group Meeting/Scheduling* - Because of all of our heavy workload, we decided on Discord as our main source of communication. There we were able to communicate in a very timely manner at any given point in the day no matter location constraints or scheduling conflicts. During project development the group discord remained active every day with questions being answered within a few minutes. Though we would maintain active communication most days, every week we would meet over a voice call and discuss what was currently in progress as well as what we would need to complete/begin working on moving forward. In the case that a team member became inactive or was taking additional time with a task, I would reach out to make sure that everything was okay and provide any needed assistance with the task.

*Project Documents* - I took full responsibility of the project documents(such as the Initial Plan, Gantt Chart, Progress Reports, & Project Document). In order to take load off of the other members and free up time for them to tackle more of the heavy programming related tasks, I made sure to be the main organizer/coordinator towards the documentation of the project. When approaching each document I would take note of each group members' input and elaborate further in order to fulfill the requirements of the document. I worked closely with each member to ensure that everyone's input would make its way on to every document.

*Repository Management* - Most of the time we were able to complete tasks without having issues merging back on to the main branch. This was due to the fact that a lot of our tasks were able to be further broken down in a way that pushes and commits could be completed quite quickly one after the other. This resulted in very few conflicts because of very little overlapping work. Though, at the few times that we would run into a merge conflict, I was responsible for stepping in to work with both sides of the conflict and manually resolve it myself.

*Minor General Development* - As the producer I was not in charge of any of the major gameplay mechanics or functions. However due to time constraints I was needed to develop and tweak certain parts of features as well as minor features such as enemy and projectile prefabs, enemy spawning, projectile instantiation, and enemy strength.

## User Interface and Input

**Describe your user interface and how it relates to gameplay. This can be done via the template.**
**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals - Timothy Shen
### Asset Creation
Given that the game's theme is Cyberpunk, the style guide and art will mostly reflect that idea. Thus there were two prevailing themes in the art: (1) **dark colors** or (2) **neon/very bright colors** as typically Cyberpunk cities are set at night/dark with neon lights to exemplify the "technologies." 

All assets, unless explicity specified otherwise, is created by me through the use of the open-source digit art software, [Krita](https://krita.org/en/). All animations of players and enemies are done in 64 by 64 pixels to allow for slightly more detail, while other assets are done in 32 by 32 pixels as they are in the background. 
### The Map
The first thing to complete was creating a concept map to help aid and guide the direction where we wanted to take this 2D top-down shooter. 
| **Map** | <sub>*art drawn via PowerPoint*<sub>              |
| :------------: | :------------: |
| Initial Map       | <img src="./Materials/Animation & Visuals/map_design_layout.png" width="40%"> | 
| Final Map         | <img src="./Materials/Animation & Visuals/map_design_final_layout.png" width="40%"> |

The initial map showcases a city with four zones in which the player will progress through with the end goal of escaping the city at the boat deck. The final map was decided on to allow for more open space for fighting in Zone 2 and a much more challenging Zone 3 to progress through.  

Implementing the map in the game environment, I used a rectangular grid and used tile maps to create the map. Tile map was chosen because it fit the aesthetic of a 2D top-down pixel game and allowed for the most flexibility in design.

**Visual Guide for Tile Map**
 - Each tile must be **32 by 32** pixels. 
 - For Buildings (except Zone 3):
   - The general color scheme must be "dull" and "dark" allowing for neon signs to contrast it.
   - Buidings should be in similar syle across each zone, as it is a city.
 - For objects:
   - Must have a black outline around the object
   - All signs must be neon and bright colors (they do not need to be outlined)

#### Zone A - Parking Lot and Main Intersection
This is the first zone the player enters in, it contains one of the most open zones allowing for an easier fighting setting. It contains three obstacles types: Building A, dirt box, and vehicles. Building A is a corner-shaped building in which the player cannot enter with neon signs (one of them pointing towards the direction you are supposed to go). There are vehicles and a dirt corner-shaped box in the parking lot. The player can use to them to their advantage as barriers. 

Note: The vehicles are not drawn by me. They are sourced from a free-to-use assets package by Tokka, [Top Down Cars Sprite Pack 1.0](https://tokka.itch.io/top-down-car). Any other mention of vehicles in other zones are also all from this asset source.

| <sub>Zone A: Parking Lot and Main Intersection<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneA.png" width="80%"> | 
#### Zone B - Plaza and Harbor Street

The second zone boast the largest zone with a plaza area and a large street. The large area allows for the most practice and skill progression before entering the harder zones. The player will first enter the plaza in which it is bordered by a building and cyberpunk themed fences (basically neon gates). There is only one exit to zone 3 which forces you to traverse to other end of the plaza. Vehicles and dirt boxes are also scattered throughout the map as obstacles. Once you exit the plaza you enter the street in which you traverse all the way to end to enter the park (Zone 3).

| <sub>Zone B: Plaza and Harbor Street<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneB.png" width="80%"> | 
#### Zone C - Park
The third zone is the most technical challenging and unique zone. It is the smallest zone with the most obstacles. The building here is a detachment from the theme because I wanted this zone to be distinctively different given it's the most unique and challenging. So, the building designs were choen to fit with the aethestic of a park. The center most part of the zone has the least space. 

Note: The buildings in this zone only are not drawn by me. They are sourced from a free-to-use assets package by Szadi art, [Houses Pack](https://szadiart.itch.io/houses-pack). The link to the [public license](/Materials/Animation%20&%20Visuals/houses_public-license.txt).
| <sub>Zone C:  Park<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneC.png" width="80%"> | 

*Technical Aspects*

First once they enter, the parked van immediately moves to trap them in zone (the exit is blocked initially too). This is done by a simple trigger Box Collider 2D that initiates the script function `OnTriggerEnter2d` to move the van straight downward until it blocks entrance. An `Enumerator` method was employed to allow the van to move to target location in one single call. 
| <sub>Entrance Trigger BoxCollider2D<sub>| <sub>Van Moving Mechanic<sub> |<sub>Exit Trigger BoxCollider2D<sub>
| :------------: | :------------: | :------------: |
| <img src="./Materials/Animation & Visuals/Zone3EntranceCollider.png" width="50%">      | ![](/Materials/Animation%20&%20Visuals/ZoneEnterMechanic.gif) | <img src="./Materials/Animation & Visuals/Zone3ExitCollider.png" width="60%"> |

Now onto the exit. The only way for the van (the exit one) to move out of the way if it get's "scared". In other words, if you kill enough of the enemies, the van will leave. The function is created again by Box Collider 2D that checks if you killed enough enemies. If so, same script idea as above is used. 
#### Zone D - Street to Boat Deck

The final zone is a little less challenging in terms of map design. You will traverse from one end to other end of the zone where the boat deck is. The player must choose to leave on the "escape boat" (it is the boat that has the most similar coloring scheme as the player's logo).

Note: The boats are not drawn by me. They are sourced from a free-to-use assets package by Sami, [Pizel Art Sprite Speed Boats](https://samifd3f122.itch.io/free-pixel-art-boats?download). It has a CC0 1.0 license.
| <sub>Zone D: Street to Boat Deck<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneD.png" width="80%"> | 
### Map Interactions

With the buildings and other obstacles included in the map, the following tilemap hierachy was established for flexibility in adjusting certain collision parameters. This will be discussed more in [Game Feel](#game-feel-and-polish) (which was also my role), but `TileMap Collider 2D` and `RigidBody2d` was used on these obstacles so the players can interact with. A `Composite Collider 2D` was also implemented so there would not be individual tilemap colliders for each tile--making it less intensive to run.

Some colliders were adjusted to create a more realistic interaction with these objects (see [Game Feel](#game-feel-and-polish)).

#### Sorting System
With the multiple layers in the map, as sorting system was established: **(1) background** and **(2) foreground**. Any layer that does not have interactions (streets, ground, water) they were in background layer. Then the foreground are all the objects that have interactions with the player(cars, player, fences, etc.). 

Then (discussed more intently in [Game Feel](#game-feel-and-polish)) the sorting axis was by the y-axis. This is why only one layer for the foreground objects was chosen, as the further sorting is done by the y-axis location of the items. This also restricted the use of `Order Layers` as all had to be at the same order for the y-axis sorting to function properly.

### Visual Guide for Characters

Each character is animated in 64 by 64 pixels frames. Given this is a 2D top down shooter game, we decided to do 4 directions for each character (up, down, left, right).

Specific Visual Guides:
 - Each character must have a black outlines.
 - The character must have at least one facial "cyberpunk" characteristics (mask, hair, etc.)
 - The gun must be a bright neon color with.
### The Player

The player visually is a relatively normal looking character with a cyberpunk mask. It's gun possess the color scheme of neon light blue and lime green. 

| **Player Up** | **Player Down** |**Player Left** | **Player Right** | **Player Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/player_up.gif)   | ![](/Materials/Animation%20&%20Visuals/player_down.gif) | ![](/Materials/Animation%20&%20Visuals/player_left.gif) | ![](/Materials/Animation%20&%20Visuals/player_right.gif) |![](/Materials/Animation%20&%20Visuals/player_idle.gif)|

### Enemies

*Gang A*

The gang will progressively get more "cyperbunk". So the first gang is just a simple enemy with a crazy mohawk. It's gun is neon red/orange.
| **Enemy A Up** | **Enemy A Down** |**Enemy A Left** | **Enemey A Right** | **Enemey A Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemya_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemya_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemya_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemya_right.gif) |![](/Materials/Animation%20&%20Visuals/enemya_idle.gif)|

*Gang B*

The next enemy similarly is simple character. The enemy gang is characterized by a pink buzz cut and a neon purple gun.

| **Enemy B Up** | **Enemy B Down** |**Enemy B Left** | **Enemey B Right** | **Enemey B Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyb_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyb_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyb_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyb_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyb_idle.gif)|

*Gang C*

Given this is for Zone C, the gang now well look more technologically advanced to match the higher skilled gameplay. Thus this gang is characterized by a cyperbunk themed helmet and holding a neon bright green gun. 

| **Enemy C Up** | **Enemy C Down** |**Enemy C Left** | **Enemey C Right** | **Enemey C Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyc_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyc_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyc_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyc_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyc_idle.gif)|

*Gang D*

Finally gang D, similar to gang C will wear a cyberpunk themed helmet. This time it's gun is neon blue.

| **Enemy D Up** | **Enemy D Down** |**Enemy D Left** | **Enemey D Right** | **Enemey D Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyd_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyd_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyd_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyd_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyd_idle.gif)|

### Animation Set Up
After each frame is drawn in Krita, a spritesheet is created for each animation state. Then in Unity, in the `Animation` window the animation clips for each direction was created. The animation for each character is done with 60 frames per second with each key frame at every 6 frames. This was chosen because it best matched the set movement speed for each character.


Both the players' and enemies' animation controllers were set up under a similar structure: a blend tree.

#### Player Animator
The animator for the player has two trees: idle and walking. For each tree, the player has four directions it can go (up, down, right, left). The blend type set then is `2D Simple Directional`. Within the `PlayerMovement.cs`, if the player moves (ie W,A,S,D is pressed) it sets `IsWalking` to true trigger the walking state. If the player is not moving, it is in the idle state by setting `IsWalking` to false.

For each state, a motion field is created between within a $[-1,1]^2$ subspace. Thus it finds the normalized distance and based on where it is in the motion field the proper animation plays.

| **Animator** | **Walking Blend Tree** |**Motion Field** | 
| :------------: | :------------: | :------------: | 
| <img src="./Materials/Animation & Visuals/Animator.png" width="50%">   | <img src="./Materials/Animation & Visuals/WalkingBlendTree.png" width="100%"> | <img src="./Materials/Animation & Visuals/MotionField.png" width="50%"> |
#### Enemy Animator 
The enemy's animator is much more simpler as since it is continuosly chasing the player there is no need for a idle tree. Thus it starts in an `Idle Down` state and when it begins to move it triggers the walking tree. The tree is set up exactly like in the player animator. A motion field was created to determine the proper animation. However, instead of checking for controller inputs to trigger states, in `EnemyAI.cs` it tracks the distance moved from a current update to the last update. Therefore if the distance moved is 0 (plus or minus a margin of error), the enemy's `IsWalking` is triggered to false and becomes in the `Idle Down` state.


### Weapons/Projectiles
## Game Logic

**Document the game states and game data you managed and the design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets, including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing/Bug Fixing - Lucas Nguyen
*Testing* - When testing the game I would communicate thoroughly with the team and the specific team members that were responsible for any specific bugs that I would find. The simplicity of the game mechanics meant that a lot of testing was easily solved done with the use of debugging statements and console error messages. Testing felt very efficient with discord as I was able to reach out and provide feedback very fast through messages and calls.

*Bug Fixing* - I also went through the code on my spare time to perform code cleaning to ensure that the codebase remained organized and did not get flooded with abandoned features and messy code. There were also times when a team member was not available, to respond quickly to my testing feedback. In this case, I was able to perform my own bug fixes by modifying and fixing minor sections of code. When doing so I made sure to not perform major changes, only conducting my own bug fixes if they were minor and did not majorly affect the state of the game.

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel and Polish

### Map Tweaks
### Player Interaction with Object
### Player Movement
