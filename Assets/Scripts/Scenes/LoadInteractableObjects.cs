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


    private void Start()
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
            for (int j = 0; j < Objects[i].Length; j++)
            {
                Objects[i][j].SetActive(quests[i].IsActive);
            }
        }

        // cat minigame code
        // replace with scalable solution
        if (CatMinigame != null)
        {
            if (quests[2].Tasks[0].Complete && quests[2].Tasks[1].Complete)
            {
                CatMinigame.GetComponent<SceneTransition>().Enable();
            }
        }
    }
}
