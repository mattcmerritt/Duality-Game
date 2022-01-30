using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    protected bool Completed;
    protected bool Active;

    public bool IsCompleted()
    {
        return Completed;
    }

    public bool IsActive()
    {
        return Active;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }
}
