using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileManager : MonoBehaviour
{
    public GameObject[] Piles;
    public float CycleTimer;
    public static int SuccessCount;
    public static bool ClickPhase;
    public float Easy, Medium, Hard, Wait;
    public Quests.Task FindCat;

    void Start()
    {
        SuccessCount = 0;
        CycleTimer = 5f;
        ClickPhase = false;
    }

    void Update()
    {
        if(SuccessCount >= 3)
        {
            FindCat.ForceComplete();
            FindObjectOfType<TransitionManager>().LoadRoom("OutsidePast");
        }

        if(!ClickPhase)
        {
            CycleTimer -= Time.deltaTime;
            if (CycleTimer <= 0)
            {
                Piles[Random.Range(0, Piles.Length)].GetComponent<Animator>().SetBool("Cat", true);
                if (SuccessCount == 0)
                {
                    CycleTimer = Easy;
                }
                else if (SuccessCount == 1)
                {
                    CycleTimer = Medium;
                }
                else
                {
                    CycleTimer = Hard;
                }
                ClickPhase = !ClickPhase;
            }
        }
        else
        {
            CycleTimer -= Time.deltaTime;
            if (CycleTimer <= 0)
            {
                foreach (GameObject pile in Piles)
                {
                    pile.GetComponent<Animator>().SetBool("Cat", false);
                }
                CycleTimer = Wait;
                ClickPhase = !ClickPhase;
            }
        }
    }

    public bool IsClickPhase()
    {
        return ClickPhase;
    }

    public void OnCorrectAnswer()
    {
        SuccessCount++;
        CycleTimer = Wait;
        foreach (GameObject pile in Piles)
        {
            pile.GetComponent<Animator>().SetBool("Cat", false);
        }
        ClickPhase = false;
    }

    public void OnWrongAnswer()
    {
        CycleTimer = Wait;
        foreach (GameObject pile in Piles)
        {
            pile.GetComponent<Animator>().SetBool("Cat", false);
        }
        ClickPhase = false;
    }
}
