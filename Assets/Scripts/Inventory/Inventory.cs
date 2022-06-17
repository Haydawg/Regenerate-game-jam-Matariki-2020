using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour, ISaveable
{
    public static event Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();

    public ItemDatabase itemDatabase;

    public float size;

    private void OnEnable()
    {
        Collectable.OnCollected += Add;
    }

    private void OnDisable()
    {
        Collectable.OnCollected -= Add;
    }

    [Serializable]
    private struct SaveData
    {

        public List<(string, int)> inventory;
    }
    public object SaveState()
    {
        SaveData saveData = new SaveData();
        saveData.inventory = new List<(string, int)>();
        foreach(InventoryItem inventory in inventory)
        {
            saveData.inventory.Add((inventory.itemData.itemID, inventory.stackSize));
        }
        return saveData;
    }

    public void LoadState(object state)
    {
        
        inventory.Clear();
        var saveData = (SaveData)state;
        foreach((string itemID, int stackSize) in saveData.inventory)
        { 
            for(int i = 0; i < stackSize; i++)
            {
                Add(itemDatabase.GetItem(itemID));
            }
        }
    }

    public bool Add(ItemData itemData)
    {

        if (inventory.Count < 1)
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            OnInventoryChange?.Invoke(inventory);
            return true;
        }
        bool needsNewStack = true;
        foreach (InventoryItem inventoryItem in inventory)
        {
            if (itemData == inventoryItem.itemData && inventoryItem.stackSize < itemData.stackLimit)
            {
                inventoryItem.AddToStack();
                OnInventoryChange?.Invoke(inventory);
                needsNewStack = false;
                return true;
            }

        }
        if(needsNewStack)
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            OnInventoryChange?.Invoke(inventory);
            return true;
        }
        return false;
    }
    public void Remove(InventoryItem item)
    {
        InventoryItem itemToRemove = null;
        foreach(InventoryItem inventoryItem in inventory)
        {
            if (inventoryItem == item)
            {
                itemToRemove = inventoryItem;
            }    
        }
        int itemIndex = inventory.IndexOf(itemToRemove);
        itemToRemove.RemoveFromStack();
        if (itemToRemove.stackSize == 0)
        {
            inventory.Remove(itemToRemove);
        }
        OnInventoryChange?.Invoke(inventory);
    }
    public void Remove(string itemName)
    {
        InventoryItem itemToRemove = null;
        foreach (InventoryItem inventoryItem in inventory)
        {
            if (inventoryItem.itemData.name == itemName)
            {
                itemToRemove = inventoryItem;
            }
        }
        int itemIndex = inventory.IndexOf(itemToRemove);
        itemToRemove.RemoveFromStack();
        if (itemToRemove.stackSize == 0)
        {
            inventory.Remove(itemToRemove);
        }
        OnInventoryChange?.Invoke(inventory);
    }
    public int ItemCount(ItemData itemData)
    {
        int count = 0;
        foreach (InventoryItem inventoryItem in inventory)
        {
            if (inventoryItem.itemData.itemID == itemData.itemID)
            {
                count += inventoryItem.stackSize;
            }
        }
        return count;
    }
    public int ItemCount(string itemName)
    {
        int count = 0;
        foreach (InventoryItem inventoryItem in inventory)
        {
            if (inventoryItem.itemData.name == itemName)
            {
                count += inventoryItem.stackSize;
            }
        }
        return count;
    }
}
