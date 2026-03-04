using UnityEngine;

public class Target : MonoBehaviour
{
    EnemyAgent agent;

    public void Start()
    {
        agent = GetComponent<EnemyAgent>();
    }

    void Update()
    {
        Mathf.Clamp(agent.config.enemyHealth, 0, agent.config.enemyHealth);
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
