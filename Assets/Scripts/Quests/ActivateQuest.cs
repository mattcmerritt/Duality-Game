using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuest : MonoBehaviour, IActionObject
{
    public int QuestIndex;

    public void Act()
    {
        GameObject.FindObjectOfType<Quests.QuestManager>().ActivateQuest(QuestIndex);
    }
}
