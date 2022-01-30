using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private QuestTypes QuestType;
    [SerializeField]
    private Quest ActiveQuest;

    // getting the current quest from the playerprefs
    private void Start()
    {
        string currentQuest = PlayerPrefs.GetString("Quest");
        switch (currentQuest)
        {
            case "none":
                QuestType = QuestTypes.NoQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                ActiveQuest.SetActive(true);
                break;
            case "papers":
                QuestType = QuestTypes.PapersQuest;
                ActiveQuest = FindObjectOfType<PapersQuest>();
                ActiveQuest.SetActive(true);
                break;
            case "cat":
                QuestType = QuestTypes.CatQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                ActiveQuest.SetActive(true);
                break;
            case "record":
                QuestType = QuestTypes.RecordQuest;
                ActiveQuest = FindObjectOfType<Quest>();
                ActiveQuest.SetActive(true);
                break;
            default:
                QuestType = QuestTypes.UnpackingQuest;
                ActiveQuest = FindObjectOfType<UnpackingQuest>();
                ActiveQuest.SetActive(true);
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
                    PlayerPrefs.SetString("Quest", "papers");
                    // switch active quest to papers quest
                    QuestType = QuestTypes.PapersQuest;
                    ActiveQuest.SetActive(true);
                    break;
                default:
                    break;
            }

            PlayerPrefs.Save();
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