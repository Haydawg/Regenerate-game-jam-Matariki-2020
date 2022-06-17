using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingInventory : MonoBehaviour
{
    [SerializeField]
    Inventory invetory;

    [SerializeField]
    List<ItemData> startingInventory;
    // Start is called before the first frame update
    void Start()
    {
        // Add starting equipment to inventory
        foreach (ItemData item in startingInventory)
            invetory.Add(item);
    }
}
