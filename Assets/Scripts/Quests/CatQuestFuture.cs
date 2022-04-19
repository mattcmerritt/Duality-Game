using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatQuestFuture : Quest
{
    // Key npcs
    [SerializeField]
    private Dialogue.NPC Owner;

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
            QuestUI.ChangeText("- Explore the town and speak to the locals");
            if (Owner != null && Owner.CheckSpokenWith())
            {
                if (!FindObjectOfType<Dialogue.DialogueUpdater>().DialogueActive)
                {
                    Completed = true;
                }
            }
        }
    }
}
