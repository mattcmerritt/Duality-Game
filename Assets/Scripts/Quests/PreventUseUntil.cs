using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventUseUntil : MonoBehaviour
{
    public Collider2D Target;
    public Quests.Task Prerequisite;
    public Quests.Task Postrequisite;

    private void Update()
    {
        if (Prerequisite.Complete)
        {
            if (Postrequisite == null || !Postrequisite.Complete)
            {
                Target.enabled = true; // prevent use unless completed
            }
            else
            {
                Target.enabled = false;
            }
        }
        else
        {
            Target.enabled = false;
        }
    }
}
