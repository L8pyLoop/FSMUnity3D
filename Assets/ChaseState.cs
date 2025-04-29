using UnityEngine;

public class ChaseState : EnemyState
{
    private Transform player;

    public ChaseState(GameObject enemy, EnemyStateMachine stateMachine, Transform player)
        : base(enemy, stateMachine)
    {
        this.player = player;
    }

    public override void LogicUpdate()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.position);

        if (distance > 7f)
        {
            stateMachine.ChangeState(new PatrolState(enemy, stateMachine, player));
            return;
        }
        else if (distance <= 1.5f)
        {
            stateMachine.ChangeState(new AttackState(enemy, stateMachine, player));
            return;
        }

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.position, Time.deltaTime * 2.5f);
    }
}
