using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour, IItemInteraction
{
    [SerializeField]
    List<Item> items;
    public bool CanInteract(Item item, out IItemInteraction interaction)
    {
        if (items.Contains(item))
        {
            interaction = this;
            return true;
        }
        else
        {
            interaction = this;
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
