using UnityEngine;

public interface ITriggerCheckable 
{
    bool IsWithAttackDistance { get; set; }

    void SetAttackDistance(bool isWithAttackDistance);
}
