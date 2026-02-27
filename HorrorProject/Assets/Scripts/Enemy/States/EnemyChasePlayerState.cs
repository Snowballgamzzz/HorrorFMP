using UnityEngine;
using UnityEngine.AI;

public class EnemyChasePlayerState : AIState
{

    float timer = 0.0f;

    public AIStateId GetId()
    {
        return AIStateId.ChasePlayer;
    }

    public void Enter(EnemyAgent agent)
    {
        if (agent.playerTransform == null)
        {

        }
    }

    public void Update(EnemyAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        if (timer < 0.0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;

            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }

            if (agent.isCollidingWithPlayer)
            {
                agent.stateMachine.ChangeState(AIStateId.AttackPlayer);
            }

            timer = agent.config.maxTime;
        }
    }

    public void Exit(EnemyAgent agent)
    {

    }
}
