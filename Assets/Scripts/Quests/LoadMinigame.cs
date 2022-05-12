using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMinigame : MonoBehaviour, IActionObject
{
    public string SceneName;

    public void Act()
    {
        FindObjectOfType<TransitionManager>().LoadRoom(SceneName);
    }
}
