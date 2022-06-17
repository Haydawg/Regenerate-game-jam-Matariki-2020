using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    public ItemData GetItem(string itemID)
    {
        foreach (var item in items)
        {
            if (item != null && item.itemID == itemID)
            {
                return item;
            }
        }
        return null;
    }
}
