# Space Attackers

## Enemy Creation and shooting

Repo: [Gizmotronn/Space-Attackers](https://github.com/Gizmotronn/space-attackers/)

Tutorial: [Zenva/Space Attackers --> Enemy Shooting](https://academy.zenva.com/lesson/enemies-shooting/)

Script: [GameController.cs]([https://github.com/Gizmotronn/space-attackers/edit/master/Space%20Attackers/Assets/Project/Scripts/GameController.cs](https://github.com/Gizmotronn/space-attackers/edit/master/Space Attackers/Assets/Project/Scripts/GameController.cs)) 

What we do here: 

* Learn how to create enemies & get them to shoot at us
* Learn more about C# in relation to the Unity Game Engine, as well as Unity itself



The dot points also represent `/#/` comments

## Commits & Issues

See these issues to follow the game in action, as well as this:

https://github.com/Gizmotronn/space-attackers/issues/4

https://github.com/Gizmotronn/space-attackers/issues/3

https://github.com/Gizmotronn/space-attackers/issues/5



## Code

### Game Controller

`**gameController.cs**` 

#### Part 1:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float shootingInterval = 3f;
    public float shootingSpeed = 3f;
    
    private float shootingTimer;
    
    // Use this for initialization
    void Start() {
        shootingTimer = shootingInterval;
    }
        
    // Update is called once per frame
    void Update() {
        
    }
}
```

`public float shootingInterval = 3f;`:

* An `enemy` will `shoot` at the `player` `GameObject` every `3 seconds`
* The enemy will (eventually) be a random enemy
  * It will shoot an `Enemy Missile Prefab`, which is different to the missile that the player shoots.
  * This is so that the missiles that the enemies shoot don't destroy the enemies (which the player missile does), and vice versa
* Right now, we've just set up a single variable (of type `float`) called `shootingInterval`, given it a value of `3f` (*3 seconds*). This doesn't actually do anything right now

`private float ShootingTimer;`:

* This is combined with `line 13` on **the above snippet (part 1)** to make sure that the enemies don't fire on us immediately, i.e. the enemies will wait for three seconds before starting to fire on us. 

`public float shootinhSpeed = 3f;`:

* Makes the speed at which the enemies' missiles are shot at us *dodgeable* 



#### Part 2:

```csharp
	void Update() {
        shootingTimer -= time.deltaTime;
        if (shootingTimer <= 0f) { // Resets the shootingTimer
            shootingTimer = shootingInterval; // Once this happens, the enemies will shoot a bullet
        }        
    }
}
```



#### Part 3:

```csharp
public class GameController : MonoBehaviour {
    public float shootingInterval = 3f;
    public float shootingSpeed = 3f;
    public gameObject enemyMissilePrefab;
    
>>>

            shootingTimer = shootingInterval; // Once this happens, the enemies will shoot a bullet
    
    		GameObject missilePrefab = Instantiate (enemyMissilePrefab);
    		missilePrefab.transform.SetParent (transform);
        }        
    }
}
```

Adding a reference to the missile

#### Part 4:

```csharp
    		Enemy[] enemies = GetComponentsInChildren<Enemy> (); // Array - see below
			Enemy randomEnemy = enemies [Random.Range(0, enemies.Length)];

			GameObject missileInstance = Instantiate (enemyMissilePrefab);
    		missilePrefab.transform.SetParent (transform);
			missilePrefab.transform.position = randomEnemy.transform.position;
        }        
    }
}
```

* Set the missile position to be the **same position** as a **random enemy** 
* The *array* `enemy[] enemies = ` provides a reference to all the enemies *gameObjects* that we have that are under the `GameController>>Enemies` in the *Unity Hierarchy*
  * Stores all of the references

`Enemy randomEnemy = enemies [Random.Range(0, enemies.Length)];`:

* `Random.Range(0, enemies,Length)];` --> we have 21 enemies (3 rows of 7), then this ensures that the only enemy that could be selected (i.e. selected to "shoot" the missile) would be enemy: 0,1,2,3,4,5,6,7,8......20 (as we have index values, like in [python](https://github.com/gizmotronn/python-learning))
  * Only possible values

`missilePrefab.transform.position = randomEnemy.transform.position;`:

* Sets the missile that will be 'launched' or 'shot' from the enemy gameObject (random enemy, note that it's just appearing in the same area as that random enemy and then going towards the player...) to the `transform.position` of the enemy that has been "chosen" by the above line. 
  * In the inspector of the game object in Unity --> transform --> position



#### Part 5:

Adding speed

```csharp
			missilePrefab.GetComponent<RigidBody2D>().velocity = new Vector2(0, -shootingSpeed);
			missilePrefab.transform.position = randomEnemy.transform.position;
        }        
    }
}
```

`missilePrefab.GetComponent<RigidBody2D>().velocity = new Vector2(0, -shootingSpeed);`:

* `new Vector2(0, -shootingSpeed);` --> Sets the x value to be 0 (in relation to the enemy --> [child objects](https://github.com/gizmotronn/unity-intro)); y value is the velocity value, shooting Speed (the velocity in the `y` direction is changing, while the *x* direction (in relation to velocity) is not = 0)
* `-shootingSpeed);` is negative because the missile will be moving downwards



#### Part 6:

Destroying the missile prefab

* This is done when it either hits the enemy or the bottom of the game window (pygame)

```csharp
			missilePrefab.GetComponent<RigidBody2D>().velocity = new Vector2(0, -shootingSpeed);
			missilePrefab.transform.position = randomEnemy.transform.position;
			Destroy(missileInstance, 3f);
        }        
    }
}
```

* Rename `missilePrefab` to `missileInstance`
  * This is because we have *instantiated* it to be the *enemyMissilePrefab* 
* Destroy it after *3 seconds* --> `3f`, so after which it would have either hit the enemy or the bottom of the gameWindow ^^



#### Rest of Part 7 --> Enemy Shooting

* You can select a series of game objects (for example, all of the `enemies` (not the gameobject called "enemies", but the gameobject*s* called "Enemy", "Enemy (1)", etc) and change certain attributes, like their scaling/transform



**Player.cs**

```csharp
..... (line 11)
    public GameObject missilePrefab;
	public GameObject explosionPrefab; 
```

https://academy.zenva.com/lesson/enemies-shooting/



#### Full script:

[`gamecontroller.cs`]([https://github.com/Gizmotronn/space-attackers/edit/master/Space%20Attackers/Assets/Project/Scripts/GameController.cs](https://github.com/Gizmotronn/space-attackers/edit/master/Space Attackers/Assets/Project/Scripts/GameController.cs)) 

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
    // Variables relating to the shooting
    public float shootingInterval = 3f; // 3 seconds
    public float shootingSpeed = 1f; // How fast the missile is shot at the player
    public GameObject enemyMissilePrefab; // Reference to enemy missile prefab 
    private float shootingTimer;

    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = shootingInterval; 
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime; // Code run every 3 seconds
        if (shootingTimer <= 0f) {
            shootingTimer = shootingInterval; // Shoot a missile at the player 

            // Setting which missile will be fired (random)
            Enemy[] enemies = GetComponentsInChildren<Enemy> (); // References to all the enemies that we have that are under the gameController in the Unity editor hierachy
            Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)]; // Fetch a new enemy, this enemy will fire a missile at the player / Index values # ensures that if we have 10 enemies, it will only give 0-9, this one is the one that fires an enemy missile

            GameObject missileInstance = Instantiate (enemyMissilePrefab); //Pass false to set the Object's position relative to its new parent.
            missileInstance.transform.SetParent (transform);
            missileInstance.transform.position = randomEnemy.transform.position;
            missileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -shootingSpeed); // -shootingSpeed because it is going to move down / 0 is how much it moves on the x plane

            // Destroy missile (prefab) after it fires
            Destroy (missileInstance, 3f); // Destroys the missile after 3 seconds            

        }
    }
}

```

