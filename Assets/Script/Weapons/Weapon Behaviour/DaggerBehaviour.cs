using UnityEngine;

public class DaggerBehaviour : ProjectileWeaponBehaviourBase
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime;
    }
}
