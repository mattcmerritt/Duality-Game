using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionItemDecision : MonoBehaviour
{
    public Quests.Task Prerequisite;
    public Quests.Task Preventer;

    public Item RequiredItem;

    public Dialogue.Conversation GoodConversation, BadConversation;

    // similar to PlayTransitionDialogue, but branches off of an item
    public void Start()
    {
        // if one thing is true but the next is not, play the transition conversation
        if (Prerequisite.Complete && !Preventer.Complete)
        {
            Dialogue.DialogueUpdater up = FindObjectOfType<Dialogue.DialogueUpdater>();

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
                    up.StartDialogue(GoodConversation.BuildConversation());
                }
            }
            if (!found)
            {
                up.StartDialogue(BadConversation.BuildConversation());
            }

            
        }
    }
}
