using UnityEngine;

[CreateAssetMenu(fileName = "[Enemy]Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyDataSO : ScriptableObject
{
    [Header("Enemy Stats")]
    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }
}
