using Unity.VisualScripting;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;

    private GameObject player; // Reference to the PlayerGameObject
    private Rigidbody2D rb; // Reference to the Rigidbody component

    private void Awake()
    {
        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find the Player GameObject by tag
    }
    private void FixedUpdate()
    {
        // movement towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
