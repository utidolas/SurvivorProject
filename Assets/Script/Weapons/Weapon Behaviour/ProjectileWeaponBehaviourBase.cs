using UnityEngine;

/*
- Meant to be the parent script of the script put on hte instantiad weapon prefab.
- To be placed on a prefab of a weapon that is a projectile weapon.
- It's easier to define movement and other types of behaviour if it's placed in the game object iteself, that is the weapon.
*/
public class ProjectileWeaponBehaviourBase : MonoBehaviour
{
    // track dir the weapon should be facing
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
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
            Debug.Log("Direction is DOWN");
            localScale.y = localScale.y * -1;
        }
        // UP
        else if(dirX == 0 && dirY > 0)
        {
            Debug.Log("Direction is UP");
            localScale.x = localScale.x * -1;
        }
        // RIGHT UP
        else if (dirX > 0 && dirY > 0)
        {
            Debug.Log("Direction is RIGHT UP");
            rotation.z = 315;
        }
        // RIGHT DOWN
        else if (dirX > 0 && dirY < 0)
        {
            Debug.Log("Direction is RIGHT DOWN");
            rotation.z = 225f;
        }
        // LEFT UP
        else if (dirX < 0 && dirY > 0)
        {
            Debug.Log("Direction is LEFT UP");
            localScale.x = localScale.x * -1;
            localScale.y = localScale.y * -1;
            rotation.z = 225f;
        }
        // LEFT DOWN
        else if (dirX < 0 && dirY < 0)
        {
            Debug.Log("Direction is LEFT DOWN");
            localScale.x = localScale.x * -1;
            localScale.y = localScale.y * -1;
            rotation.z = 315f;
        }

        transform.localScale = localScale;
        transform.rotation = Quaternion.Euler(rotation); // can't set vector rotation directly, must use Quaternion.Euler

    }
}
