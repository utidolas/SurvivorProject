using UnityEngine;

/*
- Meant to be the parent script of the script put on hte instantiad weapon prefab.
- To be placed on a prefab of a weapon that is a projectile weapon.
- It's easier to define movement and other types of behaviour if it's placed in the game object iteself, that is the weapon.
*/

public class MeleeWeaponBehaviourBase : MonoBehaviour
{
    public float destroyAfterSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    virtual protected void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }
}
