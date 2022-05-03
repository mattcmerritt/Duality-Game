using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInteractableObjects : MonoBehaviour
{
    public GameObject[] Quest1Objects;
    public GameObject[] Quest2Objects;
    public GameObject[] Quest3Objects;

    private GameObject[][] Objects;

    // cat minigame code
    // replace with scalable solution
    public GameObject CatMinigame;


    private void Start()
    {
        Objects = new GameObject[3][];
        Objects[0] = Quest1Objects;
        Objects[1] = Quest2Objects;
        Objects[2] = Quest3Objects;

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
