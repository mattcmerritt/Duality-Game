using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInteractableObjects : MonoBehaviour
{
    public GameObject[] UnpackingQuest;
    public GameObject[] PaperQuest;
    public GameObject[] ExploreFutureQuest;
    public GameObject[] CatQuest;
    public GameObject[] RecordQuest;

    private GameObject[][] Objects;

    // cat minigame code
    // replace with scalable solution
    public GameObject CatMinigame;


    private void Awake()
    {
        Objects = new GameObject[5][];
        Objects[0] = UnpackingQuest;
        Objects[1] = PaperQuest;
        Objects[2] = ExploreFutureQuest;
        Objects[3] = CatQuest;
        Objects[4] = RecordQuest;

        Quests.QuestManager qm = GameObject.FindObjectOfType<Quests.QuestManager>();
        Quests.Quest[] quests = qm.AllQuests;

        for (int i = 0; i < quests.Length; i++)
        {
            // checking completion
            bool questCompleted = true;
            foreach (Quests.Task task in quests[i].Tasks)
            {
                if (!task.Complete)
                {
                    questCompleted = false;
                }
            }

            for (int j = 0; j < Objects[i].Length; j++)
            {
                // show the object regardless of if it is interactable,
                // but change its layer to prevent the player from interacting
                Objects[i][j].layer = quests[i].IsActive ? 7 : 0;

                // only enabling if the quest is not completed
                if (quests[i].IsActive && !questCompleted)
                {
                    Objects[i][j].GetComponent<ITogglable>().Enable();
                }
            }
        }
    }

    public void ReupdateScene()
    {
        Awake();
    }
}
