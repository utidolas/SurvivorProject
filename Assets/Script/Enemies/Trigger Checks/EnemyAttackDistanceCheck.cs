using UnityEngine;

public class EnemyAttackDistanceCheck : MonoBehaviour
{
    public GameObject player; // Reference to the Player GameObject
    private EnemyBrain enemyBrain; // Reference to the EnemyBrain script

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the Player GameObject by tag
        enemyBrain = GetComponentInParent<EnemyBrain>(); // Get the EnemyBrain component attached to the parent GameObject
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemyBrain.IsWithAttackDistance = true; // Set the attack distance check to true when player enters the trigger }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemyBrain.IsWithAttackDistance = false; // Set the attack distance check to false when player enters the trigger }
        }
    }
}
