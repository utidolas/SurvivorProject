using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyStateBase CurrentEnemyState { get; private set; }

    public void Initialize(EnemyStateBase startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }

    public void ChangeState(EnemyStateBase newState)
    {
        if (CurrentEnemyState != null)
        {
            CurrentEnemyState.ExitState();
        }
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
