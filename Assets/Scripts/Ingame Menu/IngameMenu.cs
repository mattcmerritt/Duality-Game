using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public bool MenuOpen;
    public GameObject MenuUI;
    public static Quests.Quest ChosenQuest; // might need to write this to session storage to persist between scenes
    public Toggle[] QuestToggles;
    public Quests.Quest UnpackingQuest, MayorQuest, MartinQuest;
    public string[] Items; // TODO: change data type to Item or something when made

    public void Start()
    {
        MenuOpen = false;
    }

    public void MenuButtonUpdate()
    {
        if (MenuOpen)
        {
            MenuUI.SetActive(false);
            MenuOpen = false;
        }
        else
        {
            UpdateSelectedQuestTogglesOnLoad();
            MenuUI.SetActive(true);
            MenuOpen = true;
        }
    }

    public void UpdateSelectedQuestTogglesOnLoad()
    {
        foreach(Toggle t in QuestToggles)
        {
            t.isOn = false;
        }
        if (ChosenQuest == UnpackingQuest)
        {
            QuestToggles[0].isOn = true;
        }
        else if (ChosenQuest == MayorQuest)
        {
            QuestToggles[1].isOn = true;
        }
        else if (ChosenQuest == MartinQuest)
        {
            QuestToggles[2].isOn = true;
        }
        else
        {
            // no quest selected, do nothing
        }
    }

    public void SetSelectedQuest(Quests.Quest toggleQuest)
    {
        ChosenQuest = toggleQuest;
        GameObject.FindObjectOfType<Quests.QuestManager>().UpdateText();
    }
}
