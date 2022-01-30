using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersQuest : Quest
{
    // Key npcs
    [SerializeField]
    private NPC Mayor;

    // Objectives Display
    private ObjectivesUI QuestUI;

    private void Awake()
    {
        QuestUI = FindObjectOfType<ObjectivesUI>();
    }

    protected override void Update()
    {
        if (Active)
        {
            QuestUI.ChangeText("- Go speak with the mayor at the east of town");
            if (Mayor.CheckSpokenWith())
            {
                Completed = true;
                Debug.Log("Game completed");
                QuestUI.ChangeText("\nNo objectives remaining");

                if (!FindObjectOfType<DialogueUpdater>().DialogueActive)
                {
                    Debug.Log("Conversation ended");
                }
            }
        }
    }
}
