using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockable : MonoBehaviour
{
    public void CheckForBlockages()
    {
        RectTransform buttonTransform = GetComponent<RectTransform>();
        Blocker[] blockers = GameObject.FindObjectsOfType<Blocker>();
        bool blocked = false;
        foreach (Blocker b in blockers)
        {
            if(b.IsBlocking(buttonTransform))
            {
                blocked = true;
            }
        }

        if(!blocked)
        {
            // win
            Debug.Log("You picked up the item");
        }

    }
}
