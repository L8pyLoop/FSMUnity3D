using UnityEngine;

public abstract class EnemyState
{
    protected GameObject enemy;
    protected EnemyStateMachine stateMachine;

    public EnemyState(GameObject enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void LogicUpdate() { }
    public virtual void Exit() { }
}

