using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMultiQuest : MonoBehaviour, IActionObject
{
    public int[] QuestIndices;

    // activating NPCs
    public GameObject[] NPCs;

    public void Act()
    {
        foreach (int index in QuestIndices)
        {
            GameObject.FindObjectOfType<Quests.QuestManager>().ActivateQuest(index);
        }

        // activating the necessary NPCs by changing them to interactable layer
        foreach (GameObject npc in NPCs)
        {
            npc.layer = 7; // interactable
        }
    }
}
