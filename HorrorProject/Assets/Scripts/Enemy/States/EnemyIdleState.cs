using UnityEngine;

public class EnemyIdleState : AIState
{
    public AIStateId GetId()
    {
        return AIStateId.Idle;
    }

    public void Enter(EnemyAgent agent)
    {

    }

    public void Update(EnemyAgent agent)
    {
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if (playerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if (dotProduct > 0.0f)
        {
            agent.stateMachine.ChangeState(AIStateId.ChasePlayer);
        }
    }

    public void Exit(EnemyAgent agent)
    {

    }
}
