using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public EnemyAttackState(EnemyBrain enemyBrain, EnemyStateMachine enemyStateMachine) : base(enemyBrain, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhyshicsUpdate()
    {
        base.PhyshicsUpdate();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
