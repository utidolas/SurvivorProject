using UnityEngine;

public class EnemyStateBase 
{
    // references to components that are used in the state machine
    protected EnemyBrain enemyBrain;
    protected EnemyStateMachine enemyStateMachine; // ( keep track of the current state )

    // constructor to initialize the references
    public EnemyStateBase(EnemyBrain enemyBrain, EnemyStateMachine enemyStateMachine)
    {
        this.enemyBrain = enemyBrain;
        this.enemyStateMachine = enemyStateMachine;
    }

    // virtual methods to be overridden by derived states
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhyshicsUpdate() { }
    public virtual void AnimationTriggerEvent(EnemyBrain.AnimationTriggerType triggerType) { }
}
