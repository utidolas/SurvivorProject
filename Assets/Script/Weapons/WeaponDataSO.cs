using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
    // Prefab of the weapon
    [SerializeField] private GameObject weaponPrefab; 
    // Base Stats
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float cooldown;
    [SerializeField] private int pierce;

    // properties to access the weapon data. Useful because it allows us to keep the fields private and encapsulate the data.
    public GameObject WeaponPrefab { get => weaponPrefab; private set => weaponPrefab = value; }
    public float Damage { get => damage; private set => damage = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float Cooldown { get => cooldown; private set => cooldown = value; }
    public int Pierce { get => pierce; private set => pierce = value; }

}
