using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats playerStats;
    CircleCollider2D playerCollectorArea;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
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
            collectible.Collect();
        }
    }
}
