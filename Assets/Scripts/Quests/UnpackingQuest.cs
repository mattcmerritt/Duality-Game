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

            // if the player has collected all of the boxes,
            // activate the watch box
            if (boxesChecked >= 3)
            {
                WatchBox.gameObject.SetActive(true);
            }

            if (WatchBox.BoxChecked())
            {
                Completed = true;
                Exit.AllowExit();
            }
        }
    }
}
