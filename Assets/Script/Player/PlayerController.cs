using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Player Settings")]
    [SerializeField] PlayerDataSO playerData; // Reference to player data scriptable object

    // Input for movement direction
    private Vector2 movementInput;
    private bool isFacingRight = true; // Track if the player is facing right

    // References to components
    private Rigidbody2D rb; 
    private Animator anim; 

    private void Awake()
    {
        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Start()
    {
        // Initialize health in UI
        UIManager.Instance.SetHealth(playerData.health);
    }

    private void Update()
    {
        // Update animations and player facing direction
        MovementAnimation();
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * playerData.speed * Time.fixedDeltaTime);
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
        anim.SetFloat("MoveSpeed", playerData.speed);

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

    // Implementation of IDamageable interface
    public void TakeDamage(float damage)
    {
        // Deal damage and update health bar
        playerData.health -= damage;
        UIManager.Instance.UpdateHealth(playerData.health);
        
        if (playerData.health <= 0)
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
    }
}
