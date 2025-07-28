using UnityEngine;

[CreateAssetMenu(fileName = "[Attack]Data", menuName = "ScriptableObjects/AttacksSO", order = 1)]
public class AttacksSO : ScriptableObject
{
    public AnimatorOverrideController animatorOvCtrl;
    public float damage;
    public float attackSpeed; // time between attacks
}
