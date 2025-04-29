using UnityEngine;

public class AttackState : EnemyState
{
    private Transform player;
    private float attackCooldown = 1.5f;
    private float lastAttackTime = -Mathf.Infinity;

    public AttackState(GameObject enemy, EnemyStateMachine stateMachine, Transform player)
        : base(enemy, stateMachine)
    {
        this.player = player;
    }

    public override void LogicUpdate()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.position);

        if (distance > 2f)
        {
            stateMachine.ChangeState(new ChaseState(enemy, stateMachine, player));
            return;
        }

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("Enemy Attacks!");
            lastAttackTime = Time.time;
            // Tambahkan efek damage di sini
        }
    }
}
