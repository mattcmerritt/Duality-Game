using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMultiQuest : MonoBehaviour, IActionObject
{
    public int[] QuestIndices;

    public void Act()
    {
        foreach (int index in QuestIndices)
        {
            GameObject.FindObjectOfType<Quests.QuestManager>().ActivateQuest(index);
        }
    }
}
