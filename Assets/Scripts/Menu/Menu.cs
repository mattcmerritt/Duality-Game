using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Quests.Quest[] AllQuests;

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        ResetQuests();
        SceneManager.LoadScene("OpeningRoom");
    }

    public void ResetQuests()
    {
        foreach (Quests.Quest currentQuest in AllQuests)
        {
            foreach (Quests.Task currentTask in currentQuest.Tasks)
            {
                currentTask.Complete = false;
            }
            currentQuest.IsActive = false;
        }
        AllQuests[0].IsActive = true;
    }
}
