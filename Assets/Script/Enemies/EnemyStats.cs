using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyDataSO EnemyData; // Reference to the EnemyData ScriptableObject

    // current stats initialized from the EnemyData ScriptableObject
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentDamage;

    internal void Awake()
    {
        currentHealth = EnemyData.MaxHealth;
        currentMoveSpeed = EnemyData.MoveSpeed;
        currentDamage = EnemyData.Damage;
    }

}
