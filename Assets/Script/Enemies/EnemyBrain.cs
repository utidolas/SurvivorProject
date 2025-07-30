using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyBrain : MonoBehaviour
{
    public EnemyDataSO enemyData; // Reference to the EnemyData ScriptableObject

    [SerializeField] private GameObject popUpDamage; // Reference to the DamagePopUp GameObject
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
    }

    private void FixedUpdate()
    {
        // movement towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce health by the damage amount
        health -= damageAmount;
        // Instantiate a damage pop-up a little higher than the enemy and set the text of the pop-up to the damage amount
        GameObject popUp = Instantiate(popUpDamage, new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z) , Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = damageAmount.ToString();

        // Check if health is less than or equal to zero, and if so, call the Die method
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        // Handle enemy death
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
