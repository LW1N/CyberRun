# Wanted: Cyber Run

## Summary

Wanted: Cyber Run is an action packed 2d run and gun game. In it, you traverse a cyberpunk city as a man wanted by the mafia! Defend yourself by upgrading your arsenal! while you try to survive endless hordes of mafia members chasing after you! Luckily, you have a way of escape, but you'll have to navigate all the way across the city, do you have what it takes to survive CyberCity?

## Project Resources

[Web-playable version of your game.](https://itch.io/)  

[YouTube link for trailer](https://www.youtube.com/watch?v=q4ZRa82txFA)

[Press Kit website link](https://oval-lilac-9njw.squarespace.com/) - when prompted, use password 'cyber' without quotations. 

[Proposal: Initial Plan](https://docs.google.com/document/d/1mTcej1XkV0b86fvPoavogw3iHswhOYx9IMi1iMxz6IA/edit?usp=sharing)  

## Gameplay Explanation

**Input**
`W` - Moves the Player up
`A` - Moves the Player to the left
`S` - Moves the Player down
`D` - Moves the Player to the right

`Mouse Cursor` - Aim Player weapon
`Left Mouse Click` - Fire Player weapon & select weapon upgrades
`Left Shift` - Activate Player Sprint
`B` - Open weapon upgrade shop

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

*Project Documents* - I took full responsibility of the project documents(such as the [Initial Plan](https://docs.google.com/document/d/1mTcej1XkV0b86fvPoavogw3iHswhOYx9IMi1iMxz6IA/edit?usp=sharing), [Gantt chart](./Materials/cyberrun_ganttchart.pdf), Progress Reports, & this Project Document). In order to take load off of the other members and free up time for them to tackle more of the heavy programming related tasks, I made sure to be the main organizer/coordinator towards the documentation of the project. When approaching each document I would take note of each group members' input and elaborate further in order to fulfill the requirements of the document. I worked closely with each member to ensure that everyone's input would make its way on to every document.

*Repository Management* - Most of the time we were able to complete tasks without having issues merging back on to the main branch. This was due to the fact that a lot of our tasks were able to be further broken down in a way that pushes and commits could be completed quite quickly one after the other. This resulted in very few conflicts because of very little overlapping work. Though, at the few times that we would run into a merge conflict, I was responsible for stepping in to work with both sides of the conflict and manually resolve it myself.

*Code Cleaning* - I also went through the code on my spare time to perform code cleaning to ensure that the codebase remained organized. Sometimes really quickly written code, forgotten scripts, commented out code, and early parts of abandoned features were left in the codebase so I had to sift through the code and clear out any forgotten mistakes. 

*Minor General Development* - As the producer I was not in charge of any of the major gameplay mechanics or functions. However due to time constraints I was needed to develop and tweak certain parts of features as well as minor features such as the components for enemy and projectile prefabs, adjusting [enemy AI](./CyberRunGame/Assets/Scripts/EnemyAI.cs), adjusting [projectile interactions](/CyberRunGame/Assets/Scripts/BeamScript.cs), and adjusting enemy strength levels.

## User Interface and Input - Henry Duong
*Management of Game Scenes* - The game has 4 scenes that it goes through during its runtime. I managed the interface necessary to navigate throughout the scenes along with providing the basic framework of what the first 2 and last scene looked like. I also implemented code that [managed the navigation](/Assets/Scripts/ButtonManager.cs)

Start Scene:

<img src="./Materials/User Interface & Input/StartScene.png" width="40%">

This scene leads to the background story scene.

Background Story Scene:

<img src="./Materials/User Interface & Input/BackgroundScene.png" width="40%">

The dialogue is navigated through using scrolling text which can be fully generated with a left click. This scene leads to the gameplay scene.

End Scene:

<img src="./Materials/User Interface & Input/EndScene.png" width="40%">

I made a small animation that scrolls the end credits and moves the restart button to the right. This scene leads back to the start scene.

*Interface Design* - I was in charge of how the game looked to the user, and worked to make it as intuitive and clean as possible. In the 3rd scene, there are multiple screens that can pop up depending on what happens to the user. These are the:

Tutorial Screen:

<img src="./Materials/User Interface & Input/TutorialScreen.png" width="40%">

The tutorial screen closes after the button and never shows up again until the game is fully restarted.

Regular Gameplay Screen:

<img src="./Materials/User Interface & Input/GameplayScreen.png" width="40%">

Shop Screen:

<img src="./Materials/User Interface & Input/ShopScreen.png" width="40%">

This scene is accessed through the press of the key B

Death Screen:

<img src="./Materials/User Interface & Input/DeathScreen.png" width="40%">

All of these were organized and managed by me to create as clean of a UI as possible. I also managed the colors of all the UI along with picking a font that matched Timothy's artistic vision of the game. As most of the art reflects the dark side of cyberpunk, I focused on making the UI pop by using bright colors. The fonts used were [Glitch Goblin by GGBotNet](/https://www.fontspace.com/glitch-goblin-font-f94950)) and [SD Dystopian by Sudezine](/https://www.fontspace.com/sd-dystopian-font-f109410), both of which were free for personal use.

Although I was not in charge of coding the entire health system, I implemented it through a sliding health bar:

<img src="./Materials/User Interface & Input/HealthBar.png" width="40%">

This was managed by [sliders](/Assets/Scripts/PlayerHealthbar.cs)

*Default Input Configuation* - The default input configuration is **WASD/arrows for movement**, the **mouse** to aim, and **left mouse button** to shoot. **B** opens up the shop for upgrades. Everything else is handled through **left clicking buttons.** The only input style our game accepts is mouse and keyboard. This is all explained to the user through the tutorial screen:

<img src="./Materials/User Interface & Input/TutorialScreen.png" width="40%">

## Movement/Physics - Jessica Frost

### Overall Physics
In our game, movement and physics are fundamental to the player experience. As such, we decided to implement a basic `2D RigidBody` component, as well as a `2D Box Collider`, for the player character. This provides a solid foundation for realistic interactions within the game world, including the basic player movement. Building on this, many environmental elements, such as buildings and terrain, utilize tilemap colliders to ensure previse collision detection and response.

Largely, the game adheres to the standard physics model, with a few modifications to enhance gameplay dynamics. One such modification is the lack of gravity affecting the characters. Since the game is a 2D top-down shooter with the intent of the player only moving up/down and left/right, gravity is largely unnecessary. Another modification is using the `Slippery` physics 2D material within the `2D RigidBody` component to reduce the game's friction. This allows the character to "slide" more easily across the ground, making the movements feel much more responsive. Since **Wanted: CyberRun** is a very fast-paced game that relies on quick movement and reactions, this design choice allows the player to navigate through obstacles and enemies with fluidity and precision. 

### Basic Player Movement
The basic player movement is contained in `PlayerMovement.cs`. Here, the `RigidBody 2D` component is used to simulate the physical movement of the player character within the game environment. In the `FixedUpdate()` method of the script, the `RigidBody 2D`'s `MovePosition` method is used to update the position of the player character based on the calculated movement vector, current player speed, and the amount of time passed since the last update [see here](https://github.com/LW1N/CyberRun/blob/642a243f32986610f5d4a7031dc76489ee38e474/CyberRunGame/Assets/Scripts/PlayerMovement.cs#L73). This provides smooth and consistent movement regardless of frame rate variations.

### Sprint
The `PlayerSprint.cs` script introduces a sprinting mechanic to the game. This allows the player character to temporarily boost their movement speed for enhanced mobility. When the player triggers the sprint action, through holding the left shift key, the script adjusts the player's speed accordingly within `PlayerMovement.cs`, overriding the default movement speed. Then, a timer is started to track the player's current sprint duration. If the timer exceeds the set sprint duration, the player is then reverted back to their original speed. If the player prematurely stops pressing the sprint key, the sprint is also terminated. 

After playing around with some different values for both the sprint duration and sprint speed, I decided to use a duration of 3 seconds and a speed roughly 50% faster than the default speed for the sprint. This was used to simulate some realism into the game. The increased speed from the sprint allows the character to move around and dodge projectiles more easily without seeming unrealistic, and the maximum sprint duration ensures that the player is not constantly sprinting to achieve a balance of regular and increased speeds. 

Within `PlayerSprint.cs`, the `Update()` method is called every frame to test for both if the character is currently pressing the sprint key, and if the current stamina is above 0 in order to determine whether to start or stop sprinting. The `FixedUpdate()` method is used to determine if the player has exceeded their sprint duration, as well as deal with some stamina related aspects. 

### Stamina

#### Basic Stamina System
As mentioned previously, I wanted to add a sense of realism to the sprint mechanic so that the player would not be able to abuse the use of increased speed. As a result, in addition to the sprint duration I implemented a stamina system in `PlayerStaminaBar.cs` to be used in tandem with the sprint mechanic. This limits the amount of sprint the player character is able to use before having to wait for the stamina to regnerate. 

When the player uses the sprint mechanic, the player's stamina will constantly be drained for the entire duration that the sprint is used. When the player stops sprinting, the stamina will cease depleting, and begin a period of regeneration instead. Should the player begin sprinting again while the stamina is still regenerating, the regeneration will halt and the stamina will resume depleting. This logic is mainly used within `PlayerSprint.cs`, as the `FixedUpdate()` method accordingly uses the stamina bar's `DecreaseStamina()` or `IncreaseStamina()` methods based on whether or not the player is sprinting. 

#### Stamina Bar
In order to add a visual indicator for the amount of stamina the player currently has, I decided to implement a sliding stamina bar very similar to the already implemented sliding health bar. The stamina bar implementation leverages Unity's UI system, utilizing slider components to physically represent the current stamina level. By configuring the slider's properties, such as fill color and appearance, I was able to customize the visual presentation of the stamina bar to suit the game's CyberPunk aesthetic. 

In order to make the stamina bar fully working, I attached the `PlayerStaminaBar.cs` to it. From there, whenever the player's stamina is increased or decreased, it will show visually on the stamina bar. 

### Camera Control
Since the game is a fast-paced top-down shooter, we decided to have the camera controller position locked onto the player character, as seen in `CameraMovement.cs`. This works well within the context of the game, as the small player icon relative to the rest of the screen, as well as the quick movements, allows for a faster feel to the game. 

One early issue with the camera controller was the precise placement of the camera. Upon playtesting feedback, we realized that the camera controller appeared fixed to the player's feet rather than the player's torso. This gave an awkward feel to the camera positioning, as well as the player's relative position on the screen. This was easily remedied by adding an offset in the y direction to the camera controller's location at any given moment. This put the camera at the player's torso, rather than their feet. 

## Animation and Visuals - Timothy Shen
### Asset Creation
Given that the game's theme is Cyberpunk, the style guide and art will mostly reflect that idea. Thus there were two prevailing themes in the art: (1) **dark colors** or (2) **neon/very bright colors**. This is because typically, Cyberpunk cities are set at night/dark with neon lights to exemplify the "technologies." 

All assets, unless explicity specified otherwise, is created by me through the use of the open-source digit art software, [Krita](https://krita.org/en/). All animations of players and enemies are done in 64 by 64 pixels to allow for slightly more detail, while other assets are done in 32 by 32 pixels as they are in the background. 
### The Map
The first thing to complete was creating a concept map to help aid and guide the direction where we wanted to take this 2D top-down shooter. 
| **Map** | <sub>*art drawn via PowerPoint*<sub>              |
| :------------: | :------------: |
| Initial Map       | <img src="./Materials/Animation & Visuals/map_design_layout.png" width="40%"> | 
| Final Map         | <img src="./Materials/Animation & Visuals/map_design_final_layout.png" width="40%"> |

The initial map showcases a city with four zones in which the player will progress through with the end goal of escaping the city at the boat deck. The final map was decided on to allow for more open space for fighting in Zone B and a much more challenging Zone C to progress through.  

Implementing the map in the game environment, I used a rectangular grid and used tile maps to create the map. Tile map was chosen because it fit the aesthetic of a 2D top-down pixel game and allowed for the most flexibility in design.

**Visual Guide for Tile Map**
 - Each tile must be **32 by 32** pixels. 
 - For Buildings (except Zone C):
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

The second zone boast the largest zone with a plaza area and a large street. The large area allows for the most practice and skill progression before entering the harder zones. The player will first enter the plaza in which it is bordered by a building and cyberpunk themed fences (basically neon gates). There is only one exit from the plaza to the street. This forces you to traverse to other end of the plaza. Vehicles and dirt boxes are also scattered throughout the map as obstacles. Once you exit the plaza you enter the street in which you traverse all the way to end to enter the park (Zone C).

| <sub>Zone B: Plaza and Harbor Street<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneB.png" width="80%"> | 
#### Zone C - Park
The third zone is the most technical challenging and unique zone. It is the smallest zone with the most obstacles. The building here is a detachment from the theme because I wanted this zone to be distinctively different given it's the most unique and challenging. So, the building designs were choSen to fit with the aethestic of a park. The center most part of the zone has the least space, however, no enemies are spawned there allowing at times a place to break while in battle.

Note: The buildings in this zone **only** are not drawn by me. They are sourced from a free-to-use assets package by Szadi art, [Houses Pack](https://szadiart.itch.io/houses-pack). The link to the [public license](/Materials/Animation%20&%20Visuals/houses_public-license.txt).
| <sub>Zone C:  Park<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneC.png" width="80%"> | 

*Technical Aspects*

First once they enter, the parked van immediately moves to trap them in zone (the exit is blocked initially too). This is done by a simple trigger Box Collider 2D that initiates the script function [`OnTriggerEnter2d`](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/CarController.cs#L13) to move the van straight downward until it blocks the entrance. An [`IEnumerator`](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/CarController.cs#L31) method was employed to allow the van to move to target location in one single call. 
| <sub>Entrance Trigger BoxCollider2D<sub>| <sub>Van Moving Mechanic<sub> |<sub>Exit Trigger BoxCollider2D<sub>
| :------------: | :------------: | :------------: |
| <img src="./Materials/Animation & Visuals/Zone3EntranceCollider.png" width="50%">      | ![](/Materials/Animation%20&%20Visuals/ZoneEnterMechanic.gif) | <img src="./Materials/Animation & Visuals/Zone3ExitCollider.png" width="60%"> |

Now onto the exit. The only way for the van (the exit one) to move out of the way if it get's "scared". In other words, if you kill enough of the enemies, the van will leave. The function is created again by Box Collider 2D that checks [if you killed enough enemies](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/CarController.cs#L20). If so, same script idea as above is used. 
#### Zone D - Street to Boat Deck

The final zone is a little less challenging in terms of map design. You will traverse from one end to other end of the zone where the boat deck is. The player must choose to leave on the "escape boat" (it is the boat that has the most similar coloring scheme as the player's logo).

Note: The boats are not drawn by me. They are sourced from a free-to-use assets package by Sami, [Pizel Art Sprite Speed Boats](https://samifd3f122.itch.io/free-pixel-art-boats?download). It has a CC0 1.0 license.
| <sub>Zone D: Street to Boat Deck<sub>              |
|  :------------: |
|  <img src="./Materials/Animation & Visuals/ZoneD.png" width="80%"> | 
### Map Interactions

With the buildings and other obstacles included in the map, the following tilemap hierachy was established for flexibility in adjusting certain collision parameters. This will be discussed more in [Game Feel](#game-feel-and-polish) (which was also my role), but `TileMap Collider 2D` and `RigidBody2d` was used on these obstacles so the players can interact with. A `Composite Collider 2D` was also implemented so there would not be individual tilemap colliders for each tile--making it less intensive to run.
| **Composite Collider 2D** |
| :------------: |
| <img src="./Materials/Animation & Visuals/BuildingACollider.png" width="50%">|

Some colliders were adjusted to create a more realistic interaction with these objects (see [Game Feel](#game-feel-and-polish)).

#### Sorting System
With the multiple layers in the map, as sorting system was established: **(1) background** and **(2) foreground**. Any layer that does not have interactions (streets, ground, water) they were in background layer. Then the foreground are all the objects that have interactions with the characters (cars, player, fences, etc.). 

Then (discussed more intently in [Game Feel](#creating-a-realistic-top-down-feel)) the sorting axis was by the y-axis. This is why only one layer for the foreground objects was chosen, as the further sorting is done by the y-axis location of the items. This also restricted the use of `Order Layers` as all had to be at the same order for the y-axis sorting to function properly.

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

The next enemy similarly is a simple character. The enemy gang is characterized by a pink buzz cut and a neon purple gun.

| **Enemy B Up** | **Enemy B Down** |**Enemy B Left** | **Enemey B Right** | **Enemey B Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyb_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyb_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyb_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyb_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyb_idle.gif)|

*Gang C*

Given this is for Zone C, the gang now will look more technologically advanced to match the higher skilled gameplay. Thus this gang is characterized by a cyperbunk themed helmet and holding a neon bright green gun. 

| **Enemy C Up** | **Enemy C Down** |**Enemy C Left** | **Enemey C Right** | **Enemey C Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyc_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyc_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyc_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyc_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyc_idle.gif)|

*Gang D*

Finally gang D, similar to gang C will wear a cyberpunk themed helmet. This time it's gun is neon blue.

| **Enemy D Up** | **Enemy D Down** |**Enemy D Left** | **Enemey D Right** | **Enemey D Idle**
| :------------: | :------------: | :------------: | :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/enemyd_up.gif)   | ![](/Materials/Animation%20&%20Visuals/enemyd_down.gif) | ![](/Materials/Animation%20&%20Visuals/enemyd_left.gif) | ![](/Materials/Animation%20&%20Visuals/enemyd_right.gif) |![](/Materials/Animation%20&%20Visuals/enemyd_idle.gif)|

*Dead Animation*

This was a last minute addition, but to make the enemies' death more realistic a simple death transition was established for the enemies. This was not needed for the player as dying leads straight to the game over screen.

| **Death Asset** | **Death Animation** |
| :------------: | :------------: | 
| <img src="./Materials/Animation & Visuals/blood.png" width="300%">  | ![](/Materials/Animation%20&%20Visuals/Death%20Animation.gif)|

### Animation Set Up
After each frame is drawn in Krita, a spritesheet is created for each animation state. Then in Unity, in the `Animation` window, the animation clips for each direction was created. The animation for each character is done with 60 frames per second with each key frame at every 6 frames. This was chosen because it best matched the set movement speed for each character.


Both the players' and enemies' animation controllers were set up under a similar structure: a blend tree.

#### Player Animator
The animator for the player has two trees: idle and walking. For each tree, the player has four directions it can go (up, down, right, left). The blend type set then is `2D Simple Directional`. Within the `PlayerMovement.cs`, if the player moves (ie W,A,S,D is pressed) it sets `IsWalking` to true, triggering the walking state. If the player is not moving, it is in the idle state by setting `IsWalking` to false.

For each state, a motion field is created between within a $[-1,1]^2$ subspace. Thus it finds the [normalized input axis](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/PlayerMovement.cs#L57), then the proper animation plays.

| **Animator** | **Walking Blend Tree** |**Motion Field** | 
| :------------: | :------------: | :------------: | 
| <img src="./Materials/Animation & Visuals/Animator.png" width="50%">   | <img src="./Materials/Animation & Visuals/WalkingBlendTree.png" width="100%"> | <img src="./Materials/Animation & Visuals/MotionField.png" width="50%"> |

#### Enemy Animator 
The enemy's animator is much more simpler as since it is continuosly chasing the player there is no need for a idle tree. Thus it starts in an `Idle Down` state and when it begins to move it triggers the walking tree. The tree is set up exactly like in the player animator. A motion field was created to determine the proper animation. However, instead of checking for controller inputs to trigger states, in [`EnemyAI.cs`](https://github.com/LW1N/CyberRun/blob/main/CyberRunGame/Assets/Scripts/EnemyAI.cs) it tracks the distance moved from a current update to the last update. Therefore if the distance moved is 0 (plus or minus a margin of error), the enemy's `IsWalking` is triggered to false and becomes in the `Idle Down` state.

In terms of the death animation, an additional state was created. This is can be transitioned from any state as long as `IsDead` boolean value is set to true. Then when it is set to true, it goes to the [dead animation and fixes its position their (via `IEnumerator`)](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/EnemyHP.cs#L43). Then after a set time, the object is destroyed.


### Weapons/Projectiles

Since this game is a shooter game and cyberpunk themed, there was only one weapon chosen which was a gun. Another reason was that in order to create another weapon, it would require a whole new set of animations with the new weapon. Ultimately, it would be too time consuming given the short time line of this project. 

| | |
| :------------: | :------------: |
| Original Designs | <img src="./Materials/Animation & Visuals/projectile.png" width="50%">| 
| Final Designs | <img src="./Materials/Animation & Visuals/projectile2.png" width="19%" style="transform: rotate(90deg);"> | 

In terms of the projectiles, originally I created a more sophisticated design so that each enemy would have a distinct projectile. However, in turn the projectiles were asymetric, thus we needed to program it facing the proper direction. Due to the time constraint and priorities in completing other more foundational pieces to the game, that idea was scrapped. So the result was projectiles that were symmetric in nature making it look correct-facing in any direction.

### End Scene

When the player enters the boat deck, there is a boat matching the player's gun color scheme. When the player enters near it, it will [trigger a `Collider2D`](https://github.com/LW1N/CyberRun/blob/de1f950e47d038b182806a519849c77d710d8684/CyberRunGame/Assets/Scripts/Endgame.cs#L17) in which it calculates the money the player has. If the player has enough money to ride the boat, the *end scene animation* is triggered. If not, a pop up will show up saying "Not Enough $$". 

NOTE: The end scene animation in the game is paired with a end credit UI made by Henry (See [UI](#user-interface-and-input---henry-duong)).

I will note the quality of the animation is more compressed in game as the animation was created in Krita. It rendered in lower resolutions given it was done in pixel resolutions.

| Pop Up when Player Has No Money | End Scene Animation|
| :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/End_Trigger.gif) | ![](/Materials/Animation%20&%20Visuals/endscene.gif) | 
## Game Logic - Kevin Lin

I have designed the first build of the game. Major of key components were later utilized in the development of the game's final version. I have taken core concepts from games such as The Binding of Isaac and Vampire Surviviors, and implemented them in such a way that it takes sense in our game. 

### Components of the game that were kept and updated   

#### Basic player movements  
I have implemented the first variation of movements that the player can perform which is controlled using WASD. There were couple fixes to player movements such as preventing faster movement when pressing two direction buttons such as up and right at the same time. Other player movement improvement was the addition of having the player be able to sprint.   

#### Player shooting   
I have implemented a simple shooting mechanic where the projectile will fire at where the mouse/cursor is located at. There are many upgrades that the projectile can recieve such as damage upgrade, projectile speed, projectile spread, etc.    
![Desktop 2024 03 21 - 14 48 51 03 (online-video-cutter com) (1)](https://github.com/LW1N/CyberRun/assets/157579854/16d83a4c-3c1f-4717-9870-deb79b044b4d)

#### Basic UI for health and money   
I have created a template UI that kept track of the player's health and money.   
![image](https://github.com/LW1N/CyberRun/assets/157579854/923bf5a4-5bd0-4e91-a61c-e6229694ff6f)   
   
#### Basic enemy AI spawning, movements, and firing   
In the early build of the game, the enemy AI was programmed in a way that the enemies will spawn in random intervals and barely outside of the player's view. Additionally, they are programmed to move towards the player and only fire a projectile when they are in vision of the player.    
![image](https://github.com/LW1N/CyberRun/assets/157579854/aec92052-83f4-472d-a0aa-53122eea6966)   
 
#### Collision detection   
When the player collides with another object whether it was an enemy or enemy projectile, the player would take damage according to the type of object. When the player fires a projectile and the projectile hits the enemy, the projectile disappears and the enemy takes damage.    
     
### Scene transitions between game scene, game over scene, item shop screen  
The scene transition for the three main scenes (game, game over, item shop) were all handled using a game manager. The game manager had various scripts for each different event such as when the player wants to continue the game, quit the game, or when the player have recieved money/gold. Furthermore the game manager was responsible for showing and hiding the correct scenes that was suppose to be shown. Buttons were used such that the player can buy items, continue, or exit the game. In the early version of the game, the idea was to have the player start in the game scene and, when they die, the game over screen will appear. The game over screen will ask the player whether they want to continue or not. If the player clicks on exit, then the game will close. If the player chooses to click continue, the item shop with the player's accumulated money will appear. The player is able to purchase items inside of the item shop. When the player is ready, the player will be revived with full HP and have the the appropriate amount of gold and upgrades. This ordering of events will soon rather be changed in the later revisions of the game.   

### Main Game Scene 
![image](https://github.com/LW1N/CyberRun/assets/157579854/325c95e1-a1b1-4199-a387-ffa0cfea6df9)   

### Game Over Scene
![image](https://github.com/LW1N/CyberRun/assets/157579854/8bfd47b3-1e28-4306-b79c-e43fb3f7f61b)   

### Item Shop Scene  
![image](https://github.com/LW1N/CyberRun/assets/157579854/0a13d717-2f65-4e65-95b8-3fbf5651e8ed)   

### Early Demo run of the game (very laggy due to image compression) 
![Desktop_2024 03 07_-_03 58 22 01 (1)](https://github.com/LW1N/CyberRun/assets/157579854/f918c7e4-c316-4d98-af08-2d755029bdfe)


## Components of the game that were added or changed after beta version 

### New Upgrades 
In previous builds of the game, the player was only able to make one upgrade. This was changed to allow the player to have multiple upgrades such as more projectile, faster projectile, following projectile, stronger projectile, and a lazer upgrade. The price for each upgrade was changed later according to how strong the item was percieved to be. Additionally, the player was now able to make more than one purchase to any given item (aside from the lazer and following projectile).   
![image](https://github.com/LW1N/CyberRun/assets/157579854/bc178e83-2b96-4601-9dbf-12e6cf314b25)

### New game logic 
When the player dies, the player is still sent to the Game Over screen, which still has two buttons (Continue and Exit). Alternatively, when the player clicks on the Continue button, they are not longer sent into the item shop. Instead of allowing the player to keep their gold and upgrades on death, the new system will punish players who are not able to complete the game in a single run. The player will lose all of their money and upgrades and will be revived at the beginning of the game. The item shop has been changed such that the player can now access the item shop when in the game screen and pauses the game. 

# Sub-Roles

## Audio - Kevin Lin
   
### cybertruck-mood-maze-main-version-15624-02-20.mp3 
Credit: https://uppbeat.io/track/mood-maze/cybertruck   
This was the main background music used for the game. This is played throughout the whole game and loops itselve when finished. I decided to have a similar background sound track to that of CyberPunk77, an uplifting tempo futuristic sounding background music. 

### arpeggiator-end-credits-wav-14644.mp3
Credit: https://pixabay.com/sound-effects/arpeggiator-end-credits-wav-14644/    
This was the end credit cutscene background music. This sound is very reminiscent of older games (early 1990s and 2000s video end credit scene music).I've selected this MP3 file because it conveys a sense of significant achievement to the player. Moreover, it instills a sense of mystery, leaving the player intrigued about what lies ahead.
   
### pixel-death-66829.mp3 
Credit: https://pixabay.com/sound-effects/pixel-death-66829/   
This mp3 was used whenever the player takes damage. This audio clip was purposely made to be much more quieter than the other sound effects as it got annoying to listen to afterwhile. Inspired by Minecraft Villager noises. Very distinct so that the player will know that they have gotten hit without checking the health bar.     
   
### beam.mp3 
Credit: https://pixabay.com/sound-effects/beam-8-43831/   
This mp3 played everytime the player decides to fire a projectile. I was going for a sound that sounds similar to what a futuristic gun would sound like. Additionally, Star Wars played a big impiration for why I have decided to chose this mp3.  
   
### cash-register-kaching-sound-effect-125042.mp3   
Credit: https://pixabay.com/sound-effects/cash-register-kaching-sound-effect-125042/   
This sound was implemented after the player was successful in making an upgrade purchase. I wanted the player to feel as if they made a big and meaningful purchase.   
   
### 02 Reign Of Chaos.mp3 
Credit: https://www.youtube.com/watch?v=dskLTjbDvfs&t=272s    
This mp3 file was used for the start and dialogue portion of the game. 




## Gameplay Testing/Bug Fixing - Lucas Nguyen
*Self Testing* - When testing the game myself, I would communicate thoroughly with the team and the specific team members that were responsible for any specific bugs that I would find. The simplicity of the game mechanics meant that a lot of testing was easily solved done with the use of debugging statements and console error messages. Testing felt very efficient with discord as I was able to reach out and provide feedback very fast through messages and calls. 

*PlayTest Sessions* - When having other people test the game, I would have them play the game for a short period of time and take note of any feedback they offered from their experience. With this feedback I was able to work with the team on suggestions and potential solutions that I also took note of. These ideas eventually turned into well thought out solutions to the feedback we were given that we integrated into our game.

| <sub>PlayTest Session #<sub> | <sub>Feedback<sub> |<sub>Notes/Solutions<sub>
| :------------: | :------------: | :------------: |
| 1 | Player doesn't stop after unpressing key. Movement feels laggy. | Investigate input lag/delay in the movement script. Most likely has to do with how the input is being handled and translated to player movement. |
| 2 | Projectiles come out of base of character and it's awkward to look at. Camera is a bit jittery and locked to base. | Adjust player model to better fit the designed sprite. Camera placement will follow. Add a firepoint to manually adjust where the projectiles come out of so it looks better. Camera smoothing will be done with an adjustment to the position lock camera script.
| 3 | Player healthbar is not accurate and doesn't change when a hit is perceived during playing. | Ensure healthbar is properly linked and possible perform a script revision.
| 4 | After killing a certain enemy, enemies spawn without the ability to fire at the player and the game breaks. | Ensure that the prefabs we are using are the ones in the asset folder and not GameObjects in the scene so that when an enemy dies we are only destroying references to the prefab asset.
| 5 | Enemies have a really high time to kill and the amount that can spawn in a short play session is really overwhelming. This makes the map harder to traverse and feels like staying put is better than moving forward. | Adjust enemy components(health, damage, speed) and the amount of total enemies spawning. Have clear map boundaries and colliders so that it is clearer and easier to identify what way we want the players to move forward. 
| 6 | Enemies are able to spawn off the map when the player is on the edge of the map and inside of objects when the player is at a certain angle/distance to said object. | Adjust the enemy spawner so that enemies spawn in zones drawn by polygon colliders instead of at a certain distance to the player/map points.
| 7 | Upgrading the player's weapon from the shop momentarily gives them the upgrade but then breaks the functionality of the weapon. | Figure out what gameobjects are being destroyed/accessed in the weapon and shop scripts and adjust. Ensure that the prefabs from the asset folder and not the scene are being used.
| 8 | Upon dying the game is sometimes treated as if it just paused and unpaused instead of an actual restart of the game including the weapon purchse. | Ensure that deaths result in a reset of player health and positioning. Check to see that other scripts do not attempt to manipulate the player's position after health reaches 0.
| 9 | There's no way to know how much money the player needs to get before it can actually leave and finish the game without first being told from a team member. | Adjust the part of the UI that represents how much money the player has, so that in the beginning of the game it displays the amount of money the player needs to get to end the game.
| 10 | It feels awkward to have the shop only available on death and it kind of goes against the theme of rolling with the punches. | Change it so that the shop is accessible during gameplay so that the player is able to upgrade their weapon and keep playing. May be harder to manage shop + killing enemies at the same time, so make the game pause on opening the shop.

*Bug Fixing* - There were also times when a team member was not available to respond quickly to my testing feedback. In this case, I was able to perform my own bug fixes by taking my time to read and learn from previously written code so that I was able to modify and fix minor sections of the overall codebase. When doing so I made sure to not perform major changes. I would only conduct my own bug fixes if they were minor and did not majorly affect the state of the game so that the rest of the team did not have to suffer any unwanted consequences of minor bug fixes.

## Narrative Design - Henry Duong

*Narrative Aspects* - The narrative is presented to the player in the beginning of the game in the form of a [dialogue box.](/Assets/Scripts/Dialogue.cs) I also handled the summary of the game in both this document as well as the Initial Plan document and pitched the CyberPunk theme. The basic story of the game was also handled by me.

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer - Jessica Frost

[Press Kit website link](https://oval-lilac-9njw.squarespace.com/) - when prompted, use password 'cyber' without quotations. 

[YouTube link for trailer](https://www.youtube.com/watch?v=q4ZRa82txFA)

### Press Kit Design Choices
For the press kit, I wanted to give a basic introduction to the game. As such, I included a short description of the overall game narration/goal. For the screenshots, I tried to choose images that displayed the diverse range of features our game has to offer. One of the best features of the game is the intricate game artwork done by Timothy, so I tried to include screenshots of as many of the different map zones as possible, while still leaving room for potential players to explore new aspects of the map on their own. Similarly, I included a screenshot of the item shop implemented by Henry and Kevin, as the arsenal upgrades are a very big part of the game's allure and functionality. Lastly, I included a screenshot of the opening cutscene implemented by Henry as it helps add key context into the goals of the game. 

As is customary, I also included a playable thumbnail of the full game trailer, as well as a supplemental link to the trailer on YouTube. 

To create the **Wanted: CyberRun** logo as seen on the press kit, I used the online resource [Font Space](https://www.fontspace.com/category/cyberpunk) to create images of the title using the CyberPunk-esque fonts that I was then able to import into the press kit. 

I created the press kit using SquareSpace, an online resource for creating simple websites. From there, I manually added all the images and text and formatted them to my liking. Since I am not a paid member of the SquareSpace service, the only way to share the website I created is by using the password 'cyber' when prompted at the link I provided earlier. In the event that the website is unable to be loaded as well as for convenience, I also provided a pdf version of the press kit available in the GitHub repository [here](https://github.com/LW1N/CyberRun/blob/main/Materials/Press%20Kit%20%26%20Trailer/PressKit.pdf). Additionally, you can find the screenshots I used [here](https://github.com/LW1N/CyberRun/tree/main/Materials/Press%20Kit%20%26%20Trailer). 

### Trailer Design Choices
Similarly to the press kit, I decided to showcase some of the most important and key elements of gameplay in the trailer. The trailer starts off on the start screen, before transitioning to the first few lines of the initial cutscene narration. Then, the trailer shows screen recordings of some of the different gameplay aspects, such as item upgrades, enemy combat, and city exploration, while still leaving some room for the watcher's imagination. 

To create the trailer, I used WonderShare Filmora application. This allowed me to splice together different screen recordings I took of the gameplay, as well as add in any necessary transitions. In order to follow the CyberPunk theme of the game, I utilized many fast-paced slide transitions, as well as a few glitch transitions between different segments of the trailer. For audio, I used one of the available audios within WonderShare Filmora aptly named 'CyberPunk City.' This is different to the audio used in the actual game, as I did not want the trailer to encompass every single aspect of our game, in order to leave some excitement left for anyone to play the actual game. 

Similarly to the press kit, I used the [CyberPunk fonts](https://www.fontspace.com/category/cyberpunk) in order to create the text transitions in the trailer. 

## Game Feel and Polish - Timothy Shen

### Player Improvements
#### Player Animation
The player animation was created to best match the movement speed. Therefore the frames (created in `Animation` window) was at 6 key frames apart. Now besides the leg movements for each direction, the player's head would be lowered a pixel every other pixel. This would create a bobbling effect to further make it look like the player is moving fast (See [Player in Animation & Visuals](#the-player)).

#### Shooting

The chosen shooting logic is so that when the player shoots in the direction where the `Mouse Button` presses. This would create an issue, if the player is not facing that direction. Originally the idea was to restrict the shooting so that it would shoot in the direction the player was facing. However, we quickly realized not only the gameplay would too hard but it would require reworking our weapon upgrades system. Therefore, a logic was created so that wherever the mouse press location is the player would briefly face that direction when it shoots. This is done by getting the normalized distance between the `Mouse Press` (via `Camera.main.ScreenToWorldPoint(Input.mousePosition)`) and `Player`. Then the animator's `X` and `Y` would be set to the corresponding distance. This matches with the system created in the player animator.

| Changing Direction Based on Mouse Shooting | When Mouse and Movement is Opposite |
| :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/GameFeel_Shooting.gif) | ![](/Materials/Animation%20&%20Visuals/GameFeel_PlayerShooting2.gif) | 

This is in done in `Update()` to reduce the input lag, a departure from the movement system which is done in `FixedUpdate()`. Now because of this, an issue occurs where the player would face the direction in the mouse during `Update()` then instantly return the direction set in `FixedUpdate()`. Thus the player would just jitter making it impossible to see what happened. So to remedy this, when a mouse button is pressed, the `FixedUpdate()` would not be called for a couple frames. Although it's still very rapid change, but now you can visual see it switch for a moment (right image above).

### Map Improvements

In terms of map improvements, the biggest emphasis was creating a top-down two dimensional feel. Given this game is not straight from the top view, there needed to have some three-dimensional feel. Furthermore, given all the sprites, map design, and objects all are drawn with three-dimensions, it's interaction had to reflect that.

#### Creating a Realistic Top Down Feel

To create this top-down feel, I edited the colliders boxes for certain sprites. For instance, for any character the `Collider 2D` box was at the feet of the characters. This is because when you interact with things on the ground the feet dictates that interaction. 
| Player vs Gate | Player vs Vehicle |
| :------------: | :------------: |
| ![](/Materials/Animation%20&%20Visuals/GameFeel_Collider.gif) | ![](/Materials/Animation%20&%20Visuals/GameFeel_Collider2.gif) | 

In turn, for objects like fences and gates there needed to add a bit of three dimensions. When the characters is infront the fence and before the colliders hit, it's character body has to be on top of it. Similar when the characters are behind it, it's body has to be behind the gate before they collide. To do this the `Collider 2D` was manually created in the `Sprite Editor` under `Custom Physics Shapes`. This allowed it to create unique colliders for each of sprite type at once. Given that the sorting order is determined by the `y-axis`, the desired feel was created.
| Creation in Sprite Eitor (Custom Physics Shape) | Custom Colliders |
| :------------: | :------------: |
|<img src="./Materials/Animation & Visuals/SpriteCollider.png" width="50%"> |<img src="./Materials/Animation & Visuals/SpriteCollider2.png" width="85%"> |

#### Spawning Improvements

The logic of the enemy spawns is so that they are spawned at the edge of the camera. However, one apparent issue is when the enemy is spawns inside `Colliders` like buildings and cars. To remedy this the `EnemySpawner.cs` was modified so that it spawns in a trigger area. This is separated in zones. Trigger zones were created to avoid `Collider` objects, then at a random spawnpoint, the script checks if it is inside any colliders (via `colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);`). If it is inside, it will try again until it spawns in an area without any colliders. An additional requirement that the player must be in the trigger zone as well to reduce the memory usage (ie if player in zone A only Zone A work--although there are some overlap to allow for a little bit of spawning before the player enters a new zone).
| Spawn Colliders (this is for Zone B) |
| :------------: | 
|<img src="./Materials/Animation & Visuals/SpawnCollider.png" width="50%"> |

### Enemy Improvements

The enemy improvements were made to create a better feel when the player hits an enemy with a bullet. 

#### Death Animation

The first addition made was the death animation. Originally when the enemy is dead, they just are destroyed. However, it made the gameplay ackward because they would just disappear with no visual aid telling you killed them. So a death animation was created (See [Enemy Animations](#enemies) for breakdown of logic). Now when the player kills an enemy, a blood spatter is created where the enemy was killed. Then under a certain amount of time it would disappear.

| Death Animation |
| :------------: | 
| ![](/Materials/Animation%20&%20Visuals/Death%20Animation.gif)|


#### Impact Animation

Before death, there still needs to be a visual and sound indication of a hit both ways (this was suggest by Lucas originally). The sound effect was implemented by Kevin. In terms of visual effect when a bullet collides with the opposing's `Collider2D` box not only is the bullet destroyed at the spot but the sprite changes color briefly showcasing a hit. Both of these changes (bullet destroy upon collision and visual changes) were made to make a bullet impact more realistic and impactful in the game.
| Visual Impact & Bullet Destruction |
| :------------: | 
| ![](/Materials/Animation%20&%20Visuals/GameFeel_Hit.gif)|

There was one game feel that was noted but unable to resolve which was at times it looked like the enemies are sliding. This is because the direction created are only in four directions. However, the enemy finds the shortest distance to the player which is in the diagonal direction. Since there's no diagonal animation due to time constraint and the four direction system was already well implement, the enemies sometimes look like they are sliding or side-stepping diagonally.
