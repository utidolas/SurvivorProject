using UnityEngine;

public class DaggerBehaviour : ProjectileWeaponBehaviourBase
{
    DaggerController daggerController;

    protected override void Start()
    {
        base.Start();
        daggerController = FindFirstObjectByType<DaggerController>();
    }

    private void Update()
    {
        // Move the dagger in the direction it is facing
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
