using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour, IActionObject
{
    public Item Item;

    public void Act()
    {
        // TODO: Implement inventory
        Debug.LogWarning("Received " + Item.Name);
    }
}
