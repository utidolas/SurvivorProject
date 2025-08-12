using UnityEngine;

public class ShieldController : WeaponControllerBase
{
    protected override void Start()
    {
        base.Start();
        // Additional initialization for shield if needed
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedShield = Instantiate(weaponData.WeaponPrefab);
        spawnedShield.transform.position = transform.position; // Set the position of the spawned shield to be the same as this object which is the player
        spawnedShield.transform.parent = transform; // Make the shield a child of the player for better organization
    }
}
