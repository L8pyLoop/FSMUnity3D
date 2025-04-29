using UnityEngine;

public class PatrolState : EnemyState
{
    private Vector3 patrolPoint;
    private Transform player;
    private float patrolRadius = 3f;

    public PatrolState(GameObject enemy, EnemyStateMachine stateMachine, Transform player)
        : base(enemy, stateMachine)
    {
        this.player = player;
    }

    public override void Enter()
    {
        patrolPoint = enemy.transform.position + new Vector3(Random.Range(-patrolRadius, patrolRadius), 0, Random.Range(-patrolRadius, patrolRadius));
    }

    public override void LogicUpdate()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.position);
        if (distance < 5f)
        {
            stateMachine.ChangeState(new ChaseState(enemy, stateMachine, player));
            return;
        }

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, patrolPoint, Time.deltaTime * 1.5f);

        if (Vector3.Distance(enemy.transform.position, patrolPoint) < 0.5f)
        {
            patrolPoint = enemy.transform.position + new Vector3(Random.Range(-patrolRadius, patrolRadius), 0, Random.Range(-patrolRadius, patrolRadius));
        }
    }
}
