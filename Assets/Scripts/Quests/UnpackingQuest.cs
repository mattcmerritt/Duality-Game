using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingQuest : Quest
{
    // Key items
    [SerializeField]
    private List<BoxScript> Boxes;
    [SerializeField]
    private BoxScript WatchBox;
    [SerializeField]
    private Dialogue.NPC WatchBoxNPC;
    [SerializeField]
    private Exit Exit;

    // Objectives Display
    private ObjectivesUI QuestUI;

    // Instance Data
    private bool HasNoticed;

    private void Awake()
    {
        QuestUI = FindObjectOfType<ObjectivesUI>();
    }

    protected override void Update()
    {
        if (Active)
        {
            int boxesChecked = 0;

            for (int i = 0; i < Boxes.Count; i++)
            {
                if (Boxes[i].BoxChecked())
                {
                    boxesChecked++;
                }
            }
            QuestUI.ChangeText("- Unpack the boxes (" + boxesChecked + "/3)");

            // if the player has collected all of the boxes,
            // activate the watch box
            if (boxesChecked >= 3)
            {
                WatchBox.gameObject.SetActive(true);
                QuestUI.ChangeText("- Unpack the boxes (" + boxesChecked + "/3)\n- Check the last box");

                if (!FindObjectOfType<Dialogue.DialogueUpdater>().DialogueActive && !HasNoticed)
                {
                    HasNoticed = true;
                    // List<DialogueLine> lines = new List<DialogueLine>();
                    // lines.Add(new DialogueLine("Huh? What�s that?", FindObjectOfType<Dialogue.PlayerCharacter>().Portrait, FindObjectOfType<Dialogue.PlayerCharacter>().Name));
                    // FindObjectOfType<DialogueUpdater>().StartDialogue(lines);
                    Dialogue.DialogueElement line = new Dialogue.Line("Huh? What�s that?", FindObjectOfType<Dialogue.PlayerCharacter>());
                    FindObjectOfType<Dialogue.DialogueUpdater>().StartDialogue(line);
                }
            }

            if (WatchBox.BoxChecked())
            {
                if (!FindObjectOfType<Dialogue.DialogueUpdater>().DialogueActive)
                {
                    Completed = true;
                    QuestUI.ChangeText("- Go speak with the mayor at the east of town");
                    Exit.AllowExit();
                }
            }
        }
    }
}
