using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // handled by AttacksSO
    public float damage; 
    public float attackSpeed;

    BoxCollider2D triggerBox;

    private void Start()
    {
        // Get the BoxCollider component attached to this GameObject
        triggerBox = GetComponent<BoxCollider2D>();
    }

    // Check for collisions with enemies and apply damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyBrain>();
        if (enemy != null)
        {
            // decrease enemy health
            enemy.health -= damage;
            Debug.Log($"Enemy hit! Remaining health: {enemy.health}");
        }
    }

    private void EnableTriggerBox()
    {
        triggerBox.enabled = true;
    }

    private void DisableTriggerBox()
    {
        triggerBox.enabled = false;
    }
}

