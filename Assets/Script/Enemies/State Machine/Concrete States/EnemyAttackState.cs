using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    private float _timer;
    private float _timeBetweenAttacks = 2f;


    public EnemyAttackState(EnemyBrain enemyBrain, EnemyStateMachine enemyStateMachine) : base(enemyBrain, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        
        // Attack when entering the attack state
        enemyBrain.enemyAnimations.AttackAnimation();

        // make the enemy speed 0 when in attack state and play idle animation
        enemyBrain.speed = 0;
        enemyBrain.enemyAnimations.IdleAnimation(); 

        Debug.Log($"Enemy Attack State Entered, set speed to: {enemyBrain.speed}");

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        //  if player not within attack distance, change to chase state 
        if (!enemyBrain.IsWithAttackDistance)
        {
            enemyStateMachine.ChangeState(enemyBrain.EnemyChaseState);
            // reset enemy speed to normal when leaving attack state
            enemyBrain.speed = enemyBrain.enemyData.Speed;
        }
        else if(_timer > _timeBetweenAttacks) // if player is in enemy attack range 
        {
            _timer = 0f;
            enemyBrain.enemyAnimations.AttackAnimation(); // Trigger attack animation
        }

        _timer += Time.deltaTime;
    }

    public override void PhyshicsUpdate()
    {
        base.PhyshicsUpdate();
    }

    public override void AnimationTriggerEvent(EnemyBrain.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

}
