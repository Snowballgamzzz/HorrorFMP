using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public AIStateId initialState;
    public NavMeshAgent navMeshAgent;
    public EnemyAgentConfig config;
    public Transform playerTransform;
    public bool isCollidingWithPlayer;
    public PlayerHealth playerHealth;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new EnemyChasePlayerState());
        stateMachine.RegisterState(new EnemyDeathState());
        stateMachine.RegisterState(new EnemyIdleState());
        stateMachine.RegisterState(new EnemyAttackPlayerState());
        stateMachine.ChangeState(initialState);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isCollidingWithPlayer = false;
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }
}
