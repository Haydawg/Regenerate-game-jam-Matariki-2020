using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void UseItem(Vector3 targetPos, IItemInteraction interaction)
    {
        Debug.Log(true);

    }
}