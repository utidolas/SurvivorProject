using UnityEngine;

[CreateAssetMenu(fileName = "[Attack]HitBox", menuName = "ScriptableObjects/HitBoxData", order = 1)]
public class AttacksHitBoxSO : ScriptableObject
{
    public Vector2 offset;
    public Vector2 size;
}
