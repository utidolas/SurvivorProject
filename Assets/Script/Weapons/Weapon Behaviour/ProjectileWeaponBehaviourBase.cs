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
        direction = dir;
    }
}
