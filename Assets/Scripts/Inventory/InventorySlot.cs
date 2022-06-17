using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    public Image icon;
    public Inventory inventory;
    public InventoryItem inventoryItem;
    public bool isPointerOver = false;
    public bool isDragging = false;

    protected Color normalColor = Color.white;



    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public void ClearSlot()
    {
        icon.enabled = false;
        inventoryItem = null;
    }

    // Update is called once per frame
    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }
        inventoryItem = item;
        icon.enabled = true;

        icon.sprite = item.itemData.sprite;
    }
    public void Remove()
    {
        inventory.Remove(inventoryItem);
    }

    // alot of this may not be needed but here becasue its an adaptation from something ive previously done, could be useful though
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }

    Vector2 originalPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;


        if (OnBeginDragEvent != null)
        {
            originalPosition = icon.transform.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.GetComponent<IItemInteraction>() != null) 
                if (hit.collider.gameObject.GetComponent<IItemInteraction>().CanInteract(inventoryItem.itemData.item))
                    inventoryItem.itemData.item.UseItem(hit.point);

        if (OnEndDragEvent != null)
        {
            icon.transform.position = originalPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            icon.transform.position = Input.mousePosition;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag)
        Debug.Log(eventData.pointerDrag);
        if (OnDropEvent != null)
            gameObject.transform.position = Input.mousePosition;
    }
}
