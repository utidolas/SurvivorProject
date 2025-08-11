using UnityEngine;

public class DaggerController : WeaponControllerBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedDagger = Instantiate(weaponData.WeaponPrefab);
        // set the position of the spawned dagger to be the same as this object which is the player
        spawnedDagger.transform.position = transform.position; 
        spawnedDagger.GetComponent<ProjectileWeaponBehaviourBase>().DirectionChecker(playerController.lastMovedVector);
    }
}
