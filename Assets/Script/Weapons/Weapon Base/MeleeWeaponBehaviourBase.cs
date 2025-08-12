using UnityEngine;

/*
- Meant to be the parent script of the script put on hte instantiad weapon prefab.
- To be placed on a prefab of a weapon that is a projectile weapon.
- It's easier to define movement and other types of behaviour if it's placed in the game object iteself, that is the weapon.
*/

public class MeleeWeaponBehaviourBase : MonoBehaviour
{
    public WeaponDataSO weaponDataSO;
    public float destroyAfterSeconds;

    // Current stats (from weaponDataSO)
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldown;
    protected int currentPierce;

    private void Awake()
    {
        // set the current stats from the weaponDataSO
        currentDamage = weaponDataSO.Damage;
        currentSpeed = weaponDataSO.Speed;
        currentCooldown = weaponDataSO.Cooldown;
        currentPierce = weaponDataSO.Pierce;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    virtual protected void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is tagged as "Enemy", get the EnemyBrain component and call TakeDamage with currentDamage
        if (collision.CompareTag("Enemy"))
        {
            EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentDamage);
            }
        }
    }
}
