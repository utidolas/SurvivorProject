using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{
    public int healthAmount = 50; // Amount of health restored by the potion

    public void Collect()
    {
        PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
        playerStats.RestoreHealth(healthAmount);
        Destroy(gameObject); // Destroy the potion after collection
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
