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

    // Constants
    private const float MoveSpeed = 5f;

    // Obtain user input every frame
    private void Update()
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

    // Move player based on their input
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + InputDirection * MoveSpeed * Time.fixedDeltaTime);
    }

    public int GetDirection()
    {
        return (int) Direction;
    }
}
