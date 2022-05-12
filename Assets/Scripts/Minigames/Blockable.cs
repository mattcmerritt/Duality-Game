using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blockable : MonoBehaviour
{
    public Item Item;
    public Quests.Task Task;

    public void CheckForBlockages()
    {
        RectTransform buttonTransform = GetComponent<RectTransform>();
        Blocker[] blockers = FindObjectsOfType<Blocker>();
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

            // add item to inventory
            IngameMenu.AddItem(Item);

            // mark tasks as completed
            Task.ForceComplete();

            // send back to overworld
            SceneManager.LoadScene("OutsideFuture");
        }

    }
}
