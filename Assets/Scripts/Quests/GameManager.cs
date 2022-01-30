using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private QuestTypes QuestType;
    private Quest ActiveQuest;

    // getting the current quest from the playerprefs
    private void Start()
    {
        string currentQuest = PlayerPrefs.GetString("Quest");
        switch (currentQuest)
        {
            case "unpacking":
                QuestType = QuestTypes.UnpackingQuest;
                ActiveQuest = FindObjectOfType<UnpackingQuest>();
                break;
            case "papers":
                QuestType = QuestTypes.PapersQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                break;
            case "cat":
                QuestType = QuestTypes.CatQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                break;
            case "record":
                QuestType = QuestTypes.RecordQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                break;
            default:
                QuestType = QuestTypes.NoQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                break;
        }
    }

    
    private void Update()
    {
        if (ActiveQuest.IsCompleted())
        {
            ActiveQuest.SetActive(false);

            switch (ActiveQuest)
            {
                case UnpackingQuest u:
                    // write papers quest to player prefs
                    // switch active quest to papers quest
                    break;
                default:
                    break;
            }
        }
    }
}

// various quests in the game
public enum QuestTypes
{
    UnpackingQuest,
    PapersQuest,
    CatQuest,
    RecordQuest,
    NoQuest,
}