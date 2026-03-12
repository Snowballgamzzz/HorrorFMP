using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public bool playerIsNear;
    EnemyAgent agent;

    void Start()
    {
        agent = GetComponentInParent<EnemyAgent>();
        playerIsNear = false;
    }

    void Update()
    {
        distanceCheck();
    }

    private void distanceCheck()
    {
        if (playerIsNear)
        {
            this.gameObject.SetActive(false);
            agent.stateMachine.ChangeState(AIStateId.ChasePlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }
}
