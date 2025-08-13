using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    public int healthAmount = 50; // Amount of health restored by the potion

    public void Collect()
    {
        PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
        playerStats.RestoreHealth(healthAmount);
    }
}
