using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [Header("Settings")]
    public float pullSpeed;

    // Reference to scripts
    PlayerStats playerStats;
    CircleCollider2D playerCollectorArea;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        playerCollectorArea = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        playerCollectorArea.radius = playerStats.currentMagnet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the collided object has the ICollectible interface, then call Collect method
        if (collision.gameObject.TryGetComponent(out ICollectible collectible))
        {
            // get the rb component attached to the item
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Vector points from to item to the player, then apply force to the item in direction
            Vector2 forceDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);


            collectible.Collect();
        }
    }
}
