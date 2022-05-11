using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventInteractUntil : MonoBehaviour
{
    public GameObject Target;
    public Quests.Task Prerequisite;

    private void Update()
    {
        if (!Prerequisite.Complete)
        {
            Target.layer = 0; // prevent interact
        }
        else
        {
            Target.layer = 7; // allow interact
        }
    }
}
