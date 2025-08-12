using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // handled by AttacksSO
    public float damage;
    public float attackSpeed;

    private HashSet<GameObject> enemiesDamaged = new HashSet<GameObject>(); // track which enemies have already been damaged

    BoxCollider2D triggerBox;

    private void Start()
    {
        // Get the BoxCollider component attached to this GameObject
        triggerBox = GetComponent<BoxCollider2D>();
    }

    // Check for collisions with enemies and apply damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if it's an enemy and it hasn't been damaged yet
        if (collision.CompareTag("Enemy") && !enemiesDamaged.Contains(collision.gameObject))
        {
            // get enemybrain component and decrease enemy health by calling its TakeDamage method
            EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
            enemy.TakeDamage(damage);

            // Add the enemy to the hit list so it won't be hit again
            enemiesDamaged.Add(collision.gameObject);
        }
    }
    public void ResetHitList()
    {
        enemiesDamaged.Clear();  // Clear the list of damaged enemies at the end of the attack

    }

    // Methods using with animation events
    private void EnableTriggerBox()
    {
        triggerBox.enabled = true;
    }

    private void DisableTriggerBox()
    {
        triggerBox.enabled = false;
    }

}

