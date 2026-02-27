using UnityEngine;

public class EnemyDeathState : AIState
{
    public AIStateId GetId()
    {
        return AIStateId.Death;
    }

    public void Enter(EnemyAgent agent)
    {
        agent.DestoryObject();
    }

    public void Update(EnemyAgent agent)
    {

    }

    public void Exit(EnemyAgent agent)
    {

    }

}
