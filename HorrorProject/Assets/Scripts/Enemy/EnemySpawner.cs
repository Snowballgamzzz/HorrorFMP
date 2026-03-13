using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    public float spawnCounter;

    public float spawnAmmount;

    private void Start()
    {
        spawnCounter = timeToSpawn;
    }

    void Update()
    {
        if (spawnAmmount > 0)
        {
            spawnCounter -= Time.deltaTime;

            if (spawnCounter <= 0)
            {
                spawnCounter = timeToSpawn;
                spawnAmmount--;

                Instantiate(enemyToSpawn, transform.position, transform.rotation);
            }
        }
    }
}
