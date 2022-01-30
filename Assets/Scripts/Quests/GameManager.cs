using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            case "explore":
                QuestType = QuestTypes.ExploreQuest;
                ActiveQuest = FindObjectOfType<CatQuestFuture>();
                ActiveQuest.SetActive(true);
                break;
            case "papers":
                QuestType = QuestTypes.PapersQuest;
                ActiveQuest = FindObjectOfType<PapersQuest>();
                ActiveQuest.SetActive(true);
                break;
            case "cat":
                QuestType = QuestTypes.CatQuest;
                ActiveQuest = FindObjectOfType<CatQuestPast>();
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
            Debug.Log("Changing Quests");
            switch (ActiveQuest)
            {
                case UnpackingQuest u:
                    // write papers quest to player prefs
                    PlayerPrefs.SetString("Quest", "papers");
                    // switch active quest to papers quest
                    QuestType = QuestTypes.PapersQuest;
                    ActiveQuest.SetActive(true);
                    Debug.Log("Changing to Papers");
                    break;
                case PapersQuest p:
                    PlayerPrefs.SetString("Quest", "explore");
                    QuestType = QuestTypes.ExploreQuest;
                    ActiveQuest.SetActive(true);
                    Debug.Log("Changing to Explore");
                    // change to next scene for next quest
                    SceneManager.LoadScene("OutsideFuture");
                    break;
                case CatQuestFuture e:
                    PlayerPrefs.SetString("Quest", "cat");
                    QuestType = QuestTypes.CatQuest;
                    ActiveQuest.SetActive(true);
                    Debug.Log("Changing to Cat");
                    // change to next scene for next quest
                    SceneManager.LoadScene("OutsidePast2");
                    break;
                case CatQuestPast c:
                    PlayerPrefs.SetString("Quest", "record");
                    QuestType = QuestTypes.RecordQuest;
                    ActiveQuest.SetActive(true);
                    Debug.Log("Changing to Record");
                    // change to next scene for next quest
                    SceneManager.LoadScene("Menu");
                    break;
                default:
                    Debug.Log("Failed Changing Quests");
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
    ExploreQuest,
}