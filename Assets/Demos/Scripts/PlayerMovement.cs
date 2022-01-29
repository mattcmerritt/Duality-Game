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
    }

    // Move player based on their input
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + InputDirection * MoveSpeed * Time.fixedDeltaTime);
    }
}
