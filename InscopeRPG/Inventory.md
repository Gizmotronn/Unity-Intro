### Bag Bars
<iframe style="width: 90%; height: 1000px; overflow: show;" src="http://ar.skinetics.tech/stellarios/docs/unify" width="100%" height="1000" scrolling="yes">Iframes not supported</iframe>

- Scripts

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/a2ea1dec-fbc5-4596-a7ea-df295cb87d03/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/a2ea1dec-fbc5-4596-a7ea-df295cb87d03/Untitled.png)

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/d3338c49-a4d2-4c26-bc2a-3181abe59033/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/d3338c49-a4d2-4c26-bc2a-3181abe59033/Untitled.png)

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/50ed1824-17f6-4769-bc9c-0c369c8d32ef/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/50ed1824-17f6-4769-bc9c-0c369c8d32ef/Untitled.png)

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/707c6117-e713-4d33-9768-d1e43d1de060/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/707c6117-e713-4d33-9768-d1e43d1de060/Untitled.png)

    ![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/4e77dd82-514a-4c79-8a82-7cbf86d07be9/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/4e77dd82-514a-4c79-8a82-7cbf86d07be9/Untitled.png)

[https://www.youtube.com/watch?v=xQodmnpoYgs&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=50](https://www.youtube.com/watch?v=xQodmnpoYgs&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=50)

I'm planning to have the action (bag) bars maybe replace the hotbar, or maybe open up a UI/context menu similar to this one in Crashlands:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8b825e60-3011-40a8-920a-b763af89f73c/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8b825e60-3011-40a8-920a-b763af89f73c/Untitled.png)

The user will be able to organise their items into different "bags", or groups, which are stored inside the multitool.

`BagBar` is a duplicate of the GameObject `ActionBar:`

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/91a84eac-8902-43e8-8fa8-cb4457e353b1/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/91a84eac-8902-43e8-8fa8-cb4457e353b1/Untitled.png)

I'll move the bag bar to the bottom right for now but this isn't going to be where it is in the game. 

### Sprites for the bag bar

```csharp
/*BagButton.cs*/
	[SerializeField]
    private Sprite full, empty;

	public Bag Bag {
        get {
            return bag;
        }

        set
        {
            if (value!= null)
            {
                GetComponent<Image>().sprite = full;
            }
            else
            {
                GetComponent<Image>().sprite = empty; // Accesses the GameObject's image component
            }
            bag = value;
        }
    }
```

If the value of the bag is `null` then we set the `empty` sprite

```csharp
using UnityEngine;
using UnityEngine.UI;
```

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8b73a586-2de2-4820-a142-c839c86a8b9d/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/8b73a586-2de2-4820-a142-c839c86a8b9d/Untitled.png)

To see these changes reflected in Unity, we need to make some changes to the `InventoryScript.cs` file:

```csharp
// Assign a bag whenever we (the character) equip(s) one
    [SerializeField]
    private BagButton[] bagButtons;
...

// Add a bag to the BagBar
    public void AddBag(Bag bag) // Take in the bag that we're equipping
    {
        foreach (BagButton bagButton in bagButtons) { // foreach loop. For each bag button that exists in the array
            if (bagButton.MyBag == null) // If the slot doesn't already have a bag equipped
            {
                bagButton.MyBag = bag;
                break;
            }
        }
    }
```

Then assign the Bag Buttons to the `Inventory` object (GameObject):

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6f73ec72-55d1-4986-94e4-41bd43ad4067/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6f73ec72-55d1-4986-94e4-41bd43ad4067/Untitled.png)

By adding 

```csharp
public void Use() {
	...
	InventoryScript.MyInstance.AddBag(this);
}
//Bag.cs
```

we now have the correct icon for the Bag inventory:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/1d8694ec-cc46-43dc-b0bb-57a7bde8bb47/Untitled.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/1d8694ec-cc46-43dc-b0bb-57a7bde8bb47/Untitled.png)

We can use a debugging snippet in `InventoryScript.cs` to test the creation of bags:`

```csharp
	//Debugging - add a new bag if the J key is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            Bag bag = Bag(Instantiate(items[0]));
            bag.Initialize(20);
            bag.Use();
        }
    }
```

To make sure that no more than 5 bags can be added/equipped to the character's inventory:

```csharp
	private List<Bag> bags = new List<Bag>(); // List of bags equipped to our inventory

    // Assign a bag whenever we (the character) equip(s) one
    [SerializeField]
    private BagButton[] bagButtons;

    /* Instantiate items we want to test in the inventory
    [SerializeField]
    private GameObject[] items; // Array */
    [SerializeField]
    private Item[] items;

    void Start () {
        // Create a bag from the array
    }

    public bool CanAddBag
    {
        get {return bags.Count < 5} // If the count, or number of bags is <5, we can add a bag to the character
    }

		// Debugging - add a new bag if the J key is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            Bag bag = Bag(Instantiate(items[0]));
            bag.Initialize(20);
            bag.Use();
        }
    }

    // Add a bag to the BagBar
    public void AddBag(Bag bag) // Take in the bag that we're equipping
    {
        foreach (BagButton bagButton in bagButtons) { // foreach loop. For each bag button that exists in the array
            if (bagButton.MyBag == null) // If the slot doesn't already have a bag equipped
            {
                bagButton.MyBag = bag;
                bags.Add(bag); // Add to list Bag
                break;
            }
        }
    }
```

`Bag.cs`:

```csharp
	public void Use() {
        if (InventoryScript.MyInstance.CanAddBag) // If we are able to add a bag, from CanAddBag in InventoryScript.cs 
        {
            //throw new System.NotImplementedException();
            MyBagScript = Instantiate(bagPrefab,InventoryScript.MyInstance.transform).GetComponent<BagScript>(); // Instantiate bag prefab with no slots in it (0 slots), as a child object of the Inventory
            MyBagScript.AddSlots(slots);

            InventoryScript.MyInstance.AddBag(this); // Equip the bag and change the icon
        }
```
