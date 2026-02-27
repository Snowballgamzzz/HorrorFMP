using UnityEngine;

public class EnemyAttackPlayerState : AIState
{
    public AIStateId GetId()
    {
        return AIStateId.AttackPlayer;
    }

    public void Enter(EnemyAgent agent)
    {

    }

    public void Update(EnemyAgent agent)
    {
        agent.navMeshAgent.destination = agent.playerTransform.position;

        agent.playerHealth.health -= agent.config.damage;

        if (!agent.isCollidingWithPlayer)
        {
            agent.stateMachine.ChangeState(AIStateId.ChasePlayer);
        }
    }

    public void Exit(EnemyAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 0.0f;
    }
}
