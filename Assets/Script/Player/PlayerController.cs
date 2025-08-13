using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable
{
    // Input for movement direction
    public Vector2 movementInput {get; private set; } // Use property to encapsulate movement input;
    private bool isFacingRight = true; // Track if the player is facing right

    // References to components
    private Rigidbody2D rb; 
    private Animator anim;
    private PlayerStats playerStats; // Reference to PlayerStats script


    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Vector2 lastMovedVector; // Store the last moved vector for the player

    private void Awake()
    {
        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>(); 
    }
     
    private void Start()
    {
        // Initialize health in UI
        UIManager.Instance.SetHealth(playerStats.currentHealth);

        lastMovedVector = new Vector2(1, 0f);
    }

    private void Update()
    {
        // Update animations and player facing direction
        MovementAnimation();
        FlipPlayer();

        // Update last moved vector based on movement input
        GetPlayerLastVector();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * playerStats.currentMoveSpeed * Time.fixedDeltaTime);
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
        anim.SetFloat("MoveSpeed", playerStats.currentMoveSpeed);

        // if the player is moving vertically, set xVelocity to 1
        if (movementInput.x == 0)
        {
            anim.SetFloat("xVelocity", Math.Abs(movementInput.y));
        }
    }

    // Get player direction in vector3 format
    public void GetPlayerLastVector()
    {

        // store the last moved vector based on movement input
        if (movementInput.x != 0)
        {
            lastHorizontalVector = movementInput.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }

        if (movementInput.y != 0)
        {
            lastVerticalVector = movementInput.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }

        // while moving diagonally, keep the last moved vector as the last horizontal and vertical vector
        if (movementInput.x != 0 && movementInput.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
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

    // Implementation of IDamageable interface
    public void TakeDamage(float damage)
    {
        // Deal damage and update health bar
        playerStats.currentHealth -= damage;
        //UIManager.Instance.UpdateHealth(playerStats.currentHealth);
        
        if (playerStats.currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Play hurt animation if not already playing or attacking
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.Play("Hurt"); // Trigger hurt animation
            }
        }
    }

    public void Die()
    {
        anim.SetTrigger("isDead");

        this.enabled = false; // Disable the PlayerController script

        PlayerCombat playerCombatScript = GetComponent<PlayerCombat>();
        playerCombatScript.enabled = false; // Disable PlayerCombat script
        UIManager.Instance.ShowDeathPanel(); // Show death panel

    }

    // Methods called by animation events
    public void DisableAnimatorAndPause()
    {
        anim.enabled = false; // Disable the animator to stop animations
        Time.timeScale = 0f; // Pause the game
    }


}
