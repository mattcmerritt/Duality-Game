using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceDialogue : MonoBehaviour, IActionObject, ITogglable
{
    public Dialogue.NPC NPC;
    public Dialogue.Conversation Conversation, AlternateConversation;
    public Quests.Task Prereq;

    public bool Used;

    public void Act()
    {
        // making the npc not interacted with
        NPC.SetSpokenWith(false);
        NPC.ReplaceConversation(Conversation, AlternateConversation);
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
