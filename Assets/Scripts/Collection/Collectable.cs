using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectable : MonoBehaviour, ICollectable
{
    public static event HandleCollection OnCollected;
    public delegate bool HandleCollection(ItemData itemData);
    public ItemData itemData;
    public void Collect()
    {
        Debug.Log("You collected a " + itemData.name);
        if ((bool)OnCollected?.Invoke(itemData))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("cannot pick up " + itemData.name);
        }
    }
}
