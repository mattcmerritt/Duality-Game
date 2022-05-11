using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTransitionDialogue : MonoBehaviour
{
    public Quests.Task Prerequisite;
    public Quests.Task Preventer;

    public Dialogue.Conversation Conversation;

    public void Start()
    {
        // if one thing is true but the next is not, play the transition conversation
        if (Prerequisite.Complete && !Preventer.Complete)
        {
            Dialogue.DialogueUpdater up = FindObjectOfType<Dialogue.DialogueUpdater>();
            up.StartDialogue(Conversation.BuildConversation());
        }
    }
}
