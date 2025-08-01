using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Stats")]
    public float health;
    public float maxHealth;
    public float speed;
    public float critChange;
    public float critDamage;
    public float baseDamage;
    public float attackSpeed;
}
