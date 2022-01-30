using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersQuest : Quest
{
    // Key npcs
    [SerializeField]
    private NPC Mayor;

    protected override void Update()
    {
        if (Active)
        {
            if (Mayor.CheckSpokenWith())
            {
                Completed = true;
                Debug.Log("Game completed");
            }
        }
    }
}
