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
        base.FrameUpdate();
    }

    public override void PhyshicsUpdate()
    {
        base.PhyshicsUpdate();

        // movement towards the player
        enemyBrain.transform.position = Vector2.MoveTowards(enemyBrain.transform.position, enemyBrain.player.transform.position, enemyBrain.speed * Time.deltaTime);
    }
}
