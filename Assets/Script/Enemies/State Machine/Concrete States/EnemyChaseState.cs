using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyChaseState : EnemyStateBase
{
    public EnemyChaseState(EnemyBrain enemyBrain, EnemyStateMachine enemyStateMachine) : base(enemyBrain, enemyStateMachine)
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

        enemyBrain.enemyAnimations.WalkAnimation(enemyBrain.speed); // Trigger walk animation with current speed

        // if the player is within attack distance, change to attack state
        if (enemyBrain.IsWithAttackDistance)
        {
            enemyStateMachine.ChangeState(enemyBrain.EnemyAttackState); // Change to attack state if within attack distance
        }
    }

    public override void PhyshicsUpdate()
    {
        base.PhyshicsUpdate();

        // movement towards the player
        enemyBrain.transform.position = Vector2.MoveTowards(enemyBrain.transform.position, enemyBrain.player.transform.position, enemyBrain.speed * Time.deltaTime);
    }
}
