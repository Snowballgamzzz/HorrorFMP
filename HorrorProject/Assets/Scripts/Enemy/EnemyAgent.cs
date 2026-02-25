using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public AIStateId initialState;
    public NavMeshAgent navMeshAgent;
    public EnemyAgentConfig config;
    public Transform playerTransform;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new EnemyChasePlayerState());
        stateMachine.RegisterState(new EnemyDeathState());
        stateMachine.RegisterState(new EnemyIdleState());
        stateMachine.ChangeState(initialState);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
