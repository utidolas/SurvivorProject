using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Weapon")]
    [SerializeField] internal GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [Header("Player Stats")]

    [SerializeField] internal float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }


    [SerializeField] internal float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }


    [SerializeField] internal float critChange;
    public float CritChange { get => critChange; private set => critChange = value; }


    [SerializeField] internal float critDamage;
    public float CritDamage { get => critDamage; private set => critDamage = value; }


    [SerializeField] internal float baseDamage;
    public float BaseDamage { get => baseDamage; private set => baseDamage = value; }

    [SerializeField] internal float attackSpeed;
    public float AttackSpeed { get => attackSpeed; private set => attackSpeed = value; }


    [SerializeField] internal float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }


    [SerializeField] internal float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }


    [SerializeField] internal float magnet;
    public float Magnet { get => magnet; private set => magnet = value; }
}
