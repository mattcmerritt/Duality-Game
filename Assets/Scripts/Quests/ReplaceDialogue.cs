using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceDialogue : MonoBehaviour, IActionObject, ITogglable
{
    public Dialogue.NPC NPC;
    public Dialogue.Conversation Conversation, AlternateConversation;
    public Quests.Task Prereq;

    public void Act()
    {
        NPC.ReplaceConversation(Conversation, AlternateConversation);
    }

    public void Enable()
    {
        Act();
    }

    public void Disable()
    {
        // method not needed
    }

    private void Start()
    {
        if (Prereq.Complete)
        {
            Act();
        }
    }
}
