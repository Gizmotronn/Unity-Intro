# Space Attackers

Repo: [Gizmotronn/Space-Attackers](https://github.com/Gizmotronn/space-attackers/)

Tutorial: [Zenva/Space Attackers --> Enemy Shooting](https://academy.zenva.com/lesson/enemies-shooting/)

What we do here: 

* Learn how to create enemies & get them to shoot at us
* Learn more about C# in relation to the Unity Game Engine, as well as Unity itself



The dot points also represent `/#/` comments

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



#### Full script:

```csharp

```

