using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDialogueSplit : MonoBehaviour, IActionObject, ITogglable
{
    public Dialogue.NPC NPC;
    public Dialogue.Conversation GoodConversation, GoodAlternateConversation;
    public Dialogue.Conversation BadConversation, BadAlternateConversation;
    public Quests.Task Prereq;
    public Item RequiredItem;

    public bool Used;

    // similar to ReplaceDialogue, but branches off of an item
    public void Act()
    {
        // making the npc not interacted with
        NPC.SetSpokenWith(false);

        // finding the item in player inventory
        Item[] inventory = IngameMenu.Items;
        bool found = false;
        foreach (Item item in inventory)
        {
            if (item == null)
            {
                continue;
            }
            if (item.Name == RequiredItem.Name)
            {
                NPC.ReplaceConversation(GoodConversation, GoodAlternateConversation);
                found = true;
            }
        }
        if (!found)
        {
            NPC.ReplaceConversation(BadConversation, BadAlternateConversation);
        }
   
        Used = true;
    }

    public void Enable()
    {
        if (!Used)
        {
            Act();
        }
    }

    public void Disable()
    {
        // method not needed
    }

    public void Reload()
    {
        // forcing a reuse
        Used = false;
        if (Prereq.Complete)
        {
            Enable();
        }
    }
}
