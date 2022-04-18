using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatQuestPast : Quest
{
    // Key npcs
    [SerializeField]
    private Demo.NPC Owner;

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
            QuestUI.ChangeText("- Talk to Martin");
            if (Owner.CheckSpokenWith())
            {
                if (!FindObjectOfType<DialogueUpdater>().DialogueActive)
                {
                    QuestUI.ChangeText("- Talk to Martin\n- Help find Martin's cat");

                    /*
                    if (true)
                    {
                        Completed = true;
                    }
                    */
                }
            }
        }
    }
}
