using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMinigame : MonoBehaviour, IActionObject
{
    public string SceneName;

    public void Act()
    {
        SceneManager.LoadScene(SceneName);
    }
}
