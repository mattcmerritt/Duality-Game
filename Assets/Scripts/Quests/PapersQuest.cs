using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PapersQuest : Quest
{
    // Key npcs
    [SerializeField]
    private Dialogue.NPC Mayor;

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
                if (!FindObjectOfType<Dialogue.DialogueUpdater>().DialogueActive)
                {
                    Completed = true;
                }
            }
        }
    }
}
