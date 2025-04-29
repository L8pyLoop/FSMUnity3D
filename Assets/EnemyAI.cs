using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 5f;
    public float attackDistance = 1.5f;

    [HideInInspector]
    public EnemyStateMachine stateMachine;

    void Start()
    {
        stateMachine = new EnemyStateMachine();
        stateMachine.Initialize(new PatrolState(gameObject, stateMachine, player));
    }

    void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }
}


