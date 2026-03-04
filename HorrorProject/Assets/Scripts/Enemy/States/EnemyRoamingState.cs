using UnityEngine;
using UnityEngine.AI;

public class EnemyRoamingState : AIState
{
    public AIStateId GetId()
    {
        return AIStateId.Roaming;
    }

    public void Enter(EnemyAgent agent)
    {

    }
    public void Update(EnemyAgent agent)
    {
        Roaming(agent);

        Vector3 playerDirection = agent.playerTransform.position - agent.transform.forward;
        if (playerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.position;

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

    private void Roaming(EnemyAgent agent)
    {
        if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(agent.transform.position, agent.range, out point))
            {
                agent.navMeshAgent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
