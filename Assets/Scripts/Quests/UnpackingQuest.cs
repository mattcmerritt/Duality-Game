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
    private Exit Exit;

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
            }

            if (WatchBox.BoxChecked())
            {
                Completed = true;
                Exit.AllowExit();
            }
        }
    }
}
