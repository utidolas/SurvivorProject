using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the collided object has the ICollectible interface, then call Collect method
        if (collision.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }
}
