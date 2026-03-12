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
    public bool canAttack;
    public PlayerHealth playerHealth;
    public FPController controller;
    public float range;
    public GameObject sensor;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new EnemyChasePlayerState());
        stateMachine.RegisterState(new EnemyDeathState());
        stateMachine.RegisterState(new EnemyIdleState());
        stateMachine.RegisterState(new EnemyAttackPlayerState());
        stateMachine.RegisterState(new EnemyRoamingState());
        stateMachine.ChangeState(initialState);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FPController>();
        isCollidingWithPlayer = false;
        canAttack = true;
    }

    private void Update()
    {
        stateMachine.Update();

        if (controller.isPaused || controller.isAtPC || controller.isAtKeypad || controller.isInspectingDocument)
        {
            navMeshAgent.isStopped = true;
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
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
            sensor.SetActive(true);
        }
    }

    public IEnumerator attackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(5);
        canAttack = true;
    }
}
