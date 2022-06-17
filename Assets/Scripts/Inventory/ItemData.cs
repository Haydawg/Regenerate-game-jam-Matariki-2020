using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemID;
    public string name;
    public Sprite sprite;
    public int stackLimit;

    [ContextMenu("Generate Id")]
    private void GenerateId()
    {
        itemID = Guid.NewGuid().ToString();
    }
}

