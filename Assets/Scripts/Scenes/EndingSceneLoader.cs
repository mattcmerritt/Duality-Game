using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneLoader : MonoBehaviour
{
    // NPCs
    public GameObject Martin, OctaviaDenice;

    // Mayor info
    public Dialogue.NPC Mayor;
    public Dialogue.Conversation GoodEnding, BadEnding;

    public bool Alone = true;

    private void Start()
    {
        // enabling other NPCs
        Item[] inventory = IngameMenu.Items;
        foreach (Item item in inventory)
        {
            if (item == null)
            {
                continue;
            }
            if (item.Name == "Cat Paw Medallion")
            {
                Martin.SetActive(true);
                Alone = false;
            }
            else if (item.Name == "Octavia and Denice's Favorite Record")
            {
                OctaviaDenice.SetActive(true);
                Alone = false;
            }
        }

        // setting up the mayor
        if (!Alone)
        {
            Mayor.ReplaceConversation(GoodEnding, null);
        }
        else
        {
            Mayor.ReplaceConversation(BadEnding, null);
        }
    }
}
