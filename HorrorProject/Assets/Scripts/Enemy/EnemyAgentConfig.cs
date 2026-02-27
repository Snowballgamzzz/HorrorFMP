using UnityEngine;

[CreateAssetMenu()]
public class EnemyAgentConfig : ScriptableObject
{
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    public float maxSightDistance = 5.0f;
    public float enemyHealth = 10.0f;
    public float damage = 2.0f;
}
