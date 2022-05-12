using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackChecker : MonoBehaviour
{
    private DraggableCan[] Cans;
    private float CheckTimer = 0f;

    public Quests.Task Task;

    private void Start()
    {
        Cans = FindObjectsOfType<DraggableCan>();
    }

    private void Update()
    {
        List<DraggableCan> top = new List<DraggableCan>();
        List<DraggableCan> middle = new List<DraggableCan>();
        List<DraggableCan> bottom = new List<DraggableCan>();

        foreach (DraggableCan can in Cans)
        {
            if(can.transform.position.y > 3)
            {
                top.Add(can);
            }
            else if(can.transform.position.y > 0)
            {
                middle.Add(can);
            }
            else
            {
                bottom.Add(can);
            }
        }

        if (Input.GetMouseButton(0))
        {
            CheckTimer = 1f;
        }
        else if (!Input.GetMouseButton(0))
        {
            if (CheckTimer >= 0f)
            {
                CheckTimer -= Time.deltaTime;
            }
            else if (top.Count >= 2 && middle.Count >= 3 && bottom.Count >= 4)
            {
                Debug.Log("Good job stacking the cans!");
                // win stuff
                // mark tasks as completed
                Task.ForceComplete();

                // send back to overworld
                FindObjectOfType<TransitionManager>().LoadRoom("GroceryFuture");
            }
        }
    }
}
