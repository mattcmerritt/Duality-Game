using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Unity Components
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator ani;

    // Instance Data
    private Vector2 InputDirection;
    private float Direction;
    private bool IsFrozen;

    // Constants
    private const float MoveSpeed = 5f;

    private void Start()
    {
        if (TimeManager.WasTimeTransition && TimeManager.HasLastLocation())
        {
            transform.position = TimeManager.GetLastLocation();
            TimeManager.WasTimeTransition = false;
        }

        // moving the player to the proper place
        ZoneManager zm = FindObjectOfType<ZoneManager>();
        if (zm != null)
        {
            zm.MovePlayerToStart();
        }

        /*
        else if (RoomManager.WasRoomTransition && RoomManager.HasLocation)
        {
            transform.position = RoomManager.LastPlayerLocation;
            RoomManager.WasRoomTransition = false;
        }
        */
    }

    // Obtain user input every frame
    private void Update()
    {
        if (!IsFrozen)
        {
            // Get movement input
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            InputDirection = new Vector2(inputX, inputY);
            InputDirection.Normalize();

            // Update animator with values
            ani.SetFloat("Horizontal", inputX);
            ani.SetFloat("Vertical", inputY);
            ani.SetFloat("Magnitude", InputDirection.magnitude);

            // Updating the player's direction
            string clipName = ani.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToLower();
            if (clipName.Contains("right"))
            {
                Direction = 0;
            }
            else if (clipName.Contains("up"))
            {
                Direction = 1;
            }
            else if (clipName.Contains("left"))
            {
                Direction = 2;
            }
            else
            {
                Direction = 3;
            }
            ani.SetFloat("Direction", Direction);
        }
    }

    // Move player based on their input
    private void FixedUpdate()
    {
        if (!IsFrozen)
        {
            rb.MovePosition(rb.position + InputDirection * MoveSpeed * Time.fixedDeltaTime);
        }
    }

    public int GetDirection()
    {
        return (int) Direction;
    }

    // Function to prevent the character from acting and moving
    public void Freeze()
    {
        IsFrozen = true;
        GetComponent<PlayerInteractions>().Freeze();
    }

    // Function to re-enable player control
    public void Unfreeze()
    {
        IsFrozen = false;
        GetComponent<PlayerInteractions>().Unfreeze();
    }
}
