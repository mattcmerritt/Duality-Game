using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipToFuture : MonoBehaviour, IActionObject
{
    public void Act()
    {
        TimeManager.ChangeTimeNoTransition("Future");
        SceneManager.LoadScene("TownHallFuture");
    }
}
