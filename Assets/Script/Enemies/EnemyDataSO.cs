using UnityEngine;

[CreateAssetMenu(fileName = "[Enemy]Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyDataSO : ScriptableObject
{
    public float Health;
    public float MaxHealth;
    public float Speed;
    public float Damage;

}
