using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // Unity Components
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private PlayerMovement movement;

    // Raycasting constants
    [SerializeField]
    private LayerMask[] LayersToHit;
    private int TargetLayer;
    private float Distance = 1f;

    // Instance Data
    private bool IsFrozen;

    // Getting layer information to prevent raycasts from hitting the player
    private void Awake()
    {
        foreach (LayerMask l in LayersToHit)
        {
            TargetLayer += l.value;
        }
    }

    // Obtain user input
    private void Update()
    {
        if (!IsFrozen)
        {
            // get the direction to check for an interact prompt in
            int direction = movement.GetDirection();
            Vector3 targetDirection = Vector3.zero;

            // check right
            if (direction == 0)
            {
                targetDirection = Vector3.right;
            }
            else if (direction == 1)
            {
                targetDirection = Vector3.up;
            }
            else if (direction == 2)
            {
                targetDirection = Vector3.left;
            }
            else
            {
                targetDirection = Vector3.down;
            }


            // check for an npc/item to interact with
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Distance, TargetLayer);
                if (hit.transform != null)
                {
                    //Debug.Log("Interacted with: " + hit.transform.name);
                    Dialogue.NPC npc = hit.transform.GetComponent<Dialogue.NPC>();
                    if (npc != null)
                    {
                        npc.StartConversation();
                    }
                }
            }

            // watch time-travel interaction
            if (TimeManager.AbilityActive && Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Changing Time");
                TimeManager.ChangeTime(gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.LogWarning("Talk to the mayor first!");
            }
        }
    }

    // Function to prevent the character from acting and moving
    public void Freeze()
    {
        IsFrozen = true;
    }

    // Function to re-enable player control
    public void Unfreeze()
    {
        IsFrozen = false;
    }
}
