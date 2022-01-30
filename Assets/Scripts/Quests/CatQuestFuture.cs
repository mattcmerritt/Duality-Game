using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatQuestFuture : Quest
{
    // Key npcs
    [SerializeField]
    private NPC Owner;

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
            if (Owner.CheckSpokenWith())
            {
                if (!FindObjectOfType<DialogueUpdater>().DialogueActive)
                {
                    Completed = true;
                }
            }
        }
    }
}
