using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileBehaviors : MonoBehaviour
{
    public PileManager Manager;
    public void OnPileClick()
    {
        if(Manager.IsClickPhase())
        {
            if (GetComponent<Animator>().GetBool("Cat"))
            {
                Manager.OnCorrectAnswer();
            }
            else
            {
                Manager.OnWrongAnswer();
            }
        }
    }
}
