using UnityEngine;

/*
- Meant to be the parent script of the script put on hte instantiad weapon prefab.
- To be placed on a prefab of a weapon that is a projectile weapon.
- It's easier to define movement and other types of behaviour if it's placed in the game object iteself, that is the weapon.
*/
public class ProjectileWeaponBehaviourBase : MonoBehaviour
{
    public WeaponDataSO weaponDataSO;

    // track dir the weapon should be facing
    protected Vector3 direction;
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

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        #region Direction Check logic for directions
        // Check for direction and set the local scale and rotation accordingly, assuming the weapon sprite is facing right by default.

        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 localScale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        // LEFT
        if (dirX < 0 && dirY == 0)
        {
            localScale.x = localScale.x * -1;
            localScale.y = localScale.y * -1;
        }
        // DOWN
        else if (dirX == 0 && dirY < 0)
        {
            localScale.y = localScale.y * -1;
            rotation.z = 360;
        }
        // UP
        else if (dirX == 0 && dirY > 0)
        {
            localScale.x = localScale.x * -1;
            rotation.z = 360;
        }
        // RIGHT UP
        else if (dirX > 0 && dirY > 0)
        {
            rotation.z = 315;
        }
        // RIGHT DOWN
        else if (dirX > 0 && dirY < 0)
        {
            rotation.z = 225f;
        }
        // LEFT UP
        else if (dirX < 0 && dirY > 0)
        {
            localScale.x = localScale.x * -1;
            localScale.y = localScale.y * -1;
            rotation.z = 225f;
        }
        // LEFT DOWN
        else if (dirX < 0 && dirY < 0)
        {
            localScale.x = localScale.x * -1;
            localScale.y = localScale.y * -1;
            rotation.z = 315f;
        }

        transform.localScale = localScale;
        transform.rotation = Quaternion.Euler(rotation); // can't set vector rotation directly, must use Quaternion.Euler
        #endregion
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the projectile hit an enemy, get the EnemyBrain component and call TakeDamage with currentDamage
        if (collision.CompareTag("Enemy"))
        {
            EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
            enemy.TakeDamage(currentDamage);

            // Reduce the pierce count after hitting an enemy
            ReducePierce(); 
        }
    }

    protected virtual void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
