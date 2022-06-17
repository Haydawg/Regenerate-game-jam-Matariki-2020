using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnRightClickEvent;

    InventorySlot dragItemSlot;
    public int slots;

    public GameObject inventoryPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public Inventory inventory;

    public GameObject layout;

    
    
    // Start is called before the first frame update


    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    // resets inventory on update
    private void ResetInventory()
    {
        foreach(Transform childTransform in layout.transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>();
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();
        for (int i = 0; i < inventory.Count; i++)
        {
            CreateInventorySlot();
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }
    // create slot for item and initialise events
    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(inventoryPrefab, layout.transform);
        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();
        newSlotComponent.OnPointerEnterEvent += slot => EventHelper(slot, OnPointerEnterEvent);
        newSlotComponent.OnPointerExitEvent += slot => EventHelper(slot, OnPointerExitEvent);
        newSlotComponent.OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
        newSlotComponent.OnBeginDragEvent += slot => EventHelper(slot, OnBeginDragEvent);
        newSlotComponent.OnEndDragEvent += slot => EventHelper(slot, OnEndDragEvent);
        newSlotComponent.OnDragEvent += slot => EventHelper(slot, OnDragEvent);
        newSlotComponent.OnDropEvent += slot => EventHelper(slot, OnDropEvent);
        inventorySlots.Add(newSlotComponent);
    }

    private void EventHelper(InventorySlot itemSlot, Action<InventorySlot> action)
    {
        if (action != null)
            action(itemSlot);
    }
}
