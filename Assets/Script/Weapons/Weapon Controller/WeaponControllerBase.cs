using UnityEngine;

/*
Base script for all weapons to inherit from.
It will control all the base features of a weapon.
 */

public class WeaponControllerBase : MonoBehaviour
{
    [Header("Weapon stats")]
    public WeaponDataSO weaponData; // Reference to the weapon data ScriptableObject
    private float currentCooldown;

    virtual protected void Start()
    {
        currentCooldown = weaponData.Cooldown;
    }

    virtual protected void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

    virtual protected void Attack()
    {
        currentCooldown = weaponData.Cooldown; // Reset cooldown
    }

}
