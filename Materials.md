# Materials

* **Materials define how an object looks in-game**

* Textures, transparency, colour, reflectiveness, etc

* Shader:
  
  * Code that defines how the game engine renders an object on the screen
  * Unity has its own standard shader

* Materials are made up of:
  
  * Shaders (custom bodywork shader)
  * Templates (for example a car texture)
  * Colour tint

  Materials inspector inside the Unity Game Engine:

![](https://user-images.githubusercontent.com/31812229/81375251-b557a100-9133-11ea-8db7-91e51d475e45.JPG) 

* Materials are assets that takes on the **properties of shaders**:
  * Shader - defines how the game engine (unity) renders the game object on the screen (code)
  * Colour, lighting, viewing angle, texture, 
* Material:
  * Shader (for example, a car texture)
  * Color/Colour tint
  * Texture

![](https://user-images.githubusercontent.com/31812229/81528467-555d3680-938f-11ea-92b8-80c8d592a4d8.JPG) 

There's a few options for what we can do with the material:

* Metallic scale
* Smoothness scale --> when light hits an object, how much reflection is there?
  * Object (game object that the material is attached to)
  * Smoothness scale = `0`: no reflection applied
  * Smoothness scale = `>0`: skybox affects 

![](https://user-images.githubusercontent.com/31812229/81529673-e9300200-9391-11ea-8bd7-f7f09b7be7c4.JPG)

**Creating & adding textures:**

* Imported the course files (which included the `textures`)
* Click the "albedo" circle to the left
* Select the texture (either premade, or make your own)

We adding a tile image as the texture (tiles/rows of rock/bricks):

![](https://user-images.githubusercontent.com/31812229/81529665-e59c7b00-9391-11ea-85f1-a4499fe40fa2.JPG)

* Increasing `tiling` in the `material inspector` adds more rows
  * `x` and `y` values for this (across and up/down)
* Scrolling textures: `offset` (can be affected **in script**)

![](https://user-images.githubusercontent.com/31812229/81529672-e7fed500-9391-11ea-88a6-4664ddb77278.JPG)

* Adding depth:
  * `Normal Map`, used the `Stones_Normal.jpg` file in `Assets/Textures` 