using Unity.VisualScripting;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public EnemyDataSO enemyData; // Reference to the EnemyData ScriptableObject

    private GameObject player; // Reference to the PlayerGameObject
    private Rigidbody2D rb; // Reference to the Rigidbody component

    // enemy stats
    public float health;
    public float maxHealth;
    public float speed;
    public float damage;


    private void Awake()
    {
        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find the Player GameObject by tag
    }

    private void Start()
    {
        // initialize enemy data
        health = enemyData.Health;
        maxHealth = enemyData.MaxHealth;
        speed = enemyData.Speed;
        damage = enemyData.Damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        // movement towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
