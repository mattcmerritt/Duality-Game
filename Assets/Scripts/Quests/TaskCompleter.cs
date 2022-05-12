using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleter : MonoBehaviour, IActionObject
{
    public Quests.Task Task;

    public void Act()
    {
        Task.ForceComplete();
    }
}
