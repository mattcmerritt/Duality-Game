using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingQuest : MonoBehaviour
{
    // Key items
    [SerializeField]
    private List<BoxScript> Boxes;
    [SerializeField]
    private Exit Exit;
    private void Update()
    {
        bool finishedUnpacking = true;
        for (int i = 0; i < Boxes.Count; i++)
        {
            if (!Boxes[i].BoxChecked())
            {
                finishedUnpacking = false;
            }
        }

        if (finishedUnpacking)
        {
            Exit.AllowExit();
        }
    }
}
