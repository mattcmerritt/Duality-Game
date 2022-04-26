using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelEnable : MonoBehaviour, ITogglable
{
    // this is what happens when the watch activates
    public void Enable()
    {
        TimeManager.AbilityActive = true;
    }

    public void Disable()
    {
        TimeManager.AbilityActive = false;
    }
}
