public enum AIStateId
{ 
ChasePlayer,
Death,
Idle
}

public interface AIState
{
    AIStateId GetId();
    void Enter(EnemyAgent agent);
    void Update(EnemyAgent agent);
    void Exit(EnemyAgent agent);
}

