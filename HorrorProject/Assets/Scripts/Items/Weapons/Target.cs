using UnityEngine;

public class Target : MonoBehaviour
{
    EnemyAgent agent;

    public void Start()
    {
        agent = GetComponent<EnemyAgent>();
    }


    public void TakeDamage(float amount)
    {
        agent.config.enemyHealth -= amount;

        if (agent.config.enemyHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        EnemyDeathState deathState = agent.stateMachine.GetState(AIStateId.Death) as EnemyDeathState;
        agent.stateMachine.ChangeState(AIStateId.Death);
    }
}
