using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Player Settings")]
    [SerializeField] PlayerDataSO playerData; // Reference to player data scriptable object

    [Header("Player Stats")]
    public float health;
    public float maxHealth;
    public float speed;
    public float critChange;
    public float critDamage;
    public float baseDamage;
    public float attackSpeed;

    // Input for movement direction
    public Vector2 movementInput {get; private set; } // Use property to encapsulate movement input;
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
        // Set player stats from PlayerDataSO
        maxHealth = playerData.maxHealth;
        health = maxHealth;
        speed = playerData.speed;
        critChange = playerData.critChange;
        critDamage = playerData.critDamage;
        baseDamage = playerData.baseDamage;
        attackSpeed = playerData.attackSpeed;

        // Initialize health in UI
        UIManager.Instance.SetHealth(health);
    }

    private void Update()
    {
        // Update animations and player facing direction
        MovementAnimation();
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
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
        anim.SetFloat("MoveSpeed", speed);

        // if the player is moving vertically, set xVelocity to 1
        if (movementInput.x == 0)
        {
            anim.SetFloat("xVelocity", Math.Abs(movementInput.y));
        }
    }

    // Get player direction in vector3 format
    public Vector3 GetPlayerDirection()
    {
        // Return the movement input as a Vector3
        return new Vector3(movementInput.x, movementInput.y, 0f);
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
        health -= damage;
        UIManager.Instance.UpdateHealth(health);
        
        if (health <= 0)
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
