[Introduction to Unity: Getting Started - Part 1/2](https://www.raywenderlich.com/7514-introduction-to-unity-getting-started-part-1-2#toc-anchor-004)

# **Part 1**

**Scene View**

- Game view -> screen aspect ratio (4:3, for example, or a device size like iPhone)

> This allows you to make sure the game looks good on all aspect ratios  and resolutions you want to support, and that no important content is  cut off. You can add a custom aspect ratio using the Plus button at the bottom of the dropdown.

**Hierarchy Window**

- Contains the list of all the gameObjects in the game (scene)
- GameObject --> object in the game or scene

GameObjects:

- Empty containers that you can customize by *adding components*

- These components permit the game object to project 

  geometry

  :

  - (from a simple cube to more complex 3d models of towers or monsters
  - Emit light
  - Act as a camera
  - Create complex behaviour *through scripts*

- Act like folders -->

  - Contain other game objects
    - Therefore useful for organising the project

Scenes:

- Typically represents a single *level* in the game
  - However, you could put the whole game in one scene
- Any GameObjects actively used in the game in the active scene will appear in the hierarchy tab
- Every new scene starts with:
  - Directional light
  - Main Camera
  - Both are game objects
- When you delete a GameObject from the hierarchy, you're removing it from the scene

**Project Window**

- Contains all *assets* used by the game
- Assets can be organised in folders

> Unity maintains metadata for each asset, so moving assets between folders in the file system breaks the metadata. If you need to make any organizational changes to your assets — especially prefabs — always perform those changes in the Project window.

**Inspector Window**

- Lets you configure any GameObject

> When you select a GameObject in the Hierarchy, the Inspector will list all the GameObject’s components and their properties.

- Light:
  - Colour field
  - Intensity field
- Values in the inspector can be altered while the game is being played

**Toolbar**

- The toolbar can be used to manipulate GameObjects *in the scene view*

[Introduction to Unity: Getting Started - Part 1/2](https://www.raywenderlich.com/7514-introduction-to-unity-getting-started-part-1-2#toc-anchor-008)

**Play Buttons**

- Lets you start and stop the game

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/cd2092a1-09a4-42cb-82ba-9b3eb4cd69e6/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/cd2092a1-09a4-42cb-82ba-9b3eb4cd69e6/Untitled.png)

When the play button is clicked:

1. The game will start
2. Button will toggle visibly to show that it has been activated
3. The "design interface" also dims to indicate that the game is active

- Any changes made while the play button is on will be lost when the play button is toggled off

Pause Button:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8fe285d1-7f72-45dc-b27c-6d46f25c8cea/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8fe285d1-7f72-45dc-b27c-6d46f25c8cea/Untitled.png)

> This pauses and lets you make modifications to the game. Just like in play mode, those modifications will be lost once you stop the game. Editing GameObjects during play and pausing is a cheat and balancing system that allows you to experiment on your game without the danger of permanently breaking it.

Step Button:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/2a3a7aa5-b062-4f93-8e26-abd85b0db0c1/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/2a3a7aa5-b062-4f93-8e26-abd85b0db0c1/Untitled.png)

> This lets you step through your game one frame at a time. This is handy when you want to observe animations on a frame-by-frame basis, or when you want to check the state of particular GameObjects during gameplay.

# Part 2

**What is covered:**

- How to use the project window to organise & import your assets
- The difference between gameObjects & prefabs
- How physics works in Unity
- How cameras work and which types of projections are available
- The basics of materials in Unity

Assets have been imported into Unity and they have also been organised in the Unity project window/tab

> Note: You’ll notice that the GameManager has a different icon from the other scripts. Most games have an object called a GameManager which acts as the overall “brain” for the game. This is a standard adopted by many developers. It’s been used so much that Unity created a special icon for it.

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/01f74701-5df3-4cb2-b1c5-d970085d2ffc/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/01f74701-5df3-4cb2-b1c5-d970085d2ffc/Untitled.png)

> At the end of the day, it’s a script like any other. The icon just helps you recognize it since you’ll access it often. There are special icons for other components as well. You’ll discover these as you dig deeper into Unity.

## Create your first instance

Look inside `models/players` in the project folder (in `assets`). A .fbx file was one of the files included here.

- .fbx files contain all the data required to make a 3D model, along with other things (like animations)

After importing this into the Unity editor, the following error pops up:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/4e3c9afb-3470-4d61-a5ce-c9c997603e0a/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/4e3c9afb-3470-4d61-a5ce-c9c997603e0a/Untitled.png)

- Some image files contain extra information for unity, but are saved in *standard image format*

> In this case, p_pod_normal.jpg defines the depths of a surface, which provides surface lighting information without the need to create additional geometry. This is called a normal map.

- Unity thinks that it's dealing with a regular image - `Fix now` instructs Unity to treat it as a `normal map`
- By default, Unity will *import cameras* with the model
  - We only need one camera for this game (which is acting as a scene in the repo). This is the `Main Camera` (*game object*). Unchecking `Import Cameras` in the *inspector* window for the file `hextraction_pod` will do this:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/b2230663-8b85-4974-948a-8a36a379d007/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/b2230663-8b85-4974-948a-8a36a379d007/Untitled.png)

- Now we'll/I'll drag the file into the scene view:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/c316fa68-b8aa-4761-b9f0-1657f7a0ed14/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/c316fa68-b8aa-4761-b9f0-1657f7a0ed14/Untitled.png)

## Working with game objects

- Everything in the `hierarchy` tab/window of the Unity game engine/editor will be a `GameObject` of some kind

- GameObjects contain a 

  ```
  transform
  ```

   —> information about the [] of the object:

  - Scale
  - Position
  - Size

- GameObjects can be customized by adding 

  components

   to them

  - Components represent the behaviour and appearance of the object

> For instance, you can add a lighting component to illuminate your GameObject. You can add an Audio Source to make your GameObject emit sound. Or you can even write your own components as scripts and attach them to GameObjects.