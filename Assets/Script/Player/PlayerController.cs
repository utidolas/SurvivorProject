using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = .5f; 

    // Input for movement direction
    private Vector2 movementInput;
    private bool isFacingRight = true; // Track if the player is facing right

    private Rigidbody2D rb; // Reference to the Rigidbody component
    private Animator anim; // Reference to the Animation component

    private void Awake()
    {
        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Update animations and player facing direction
        MovementAnimation(); 
        FlipPlayer(); 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    // move player based on input
    public void MovePlayer(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
    }

    // update animation based on movement
    private void MovementAnimation()
    {
        anim.SetFloat("xVelocity", Math.Abs(movementInput.x));

        // if the player is moving vertically, set xVelocity to 1
        if (movementInput.x == 0)
        {
            anim.SetFloat("xVelocity", Math.Abs(movementInput.y));
        }
    }

    // flip player sprite based on movement direction
    private void FlipPlayer()
    {
        // Check if the player is moving in the opposite direction of their current facing direction
        if (isFacingRight && movementInput.x < 0f || !isFacingRight && movementInput.x > 0f)
        {
            // Toggle the facing direction, get the current local scale of the player, flip it and apply it
            isFacingRight = !isFacingRight; 
            Vector3 localScale = transform.localScale; 
            localScale.x *= -1; 
            transform.localScale = localScale;
        }

    }
}
