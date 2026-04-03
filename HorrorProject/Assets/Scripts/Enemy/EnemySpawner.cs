using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    public float spawnCounter;

    public float spawnAmmount;

    public bool playerIsInRoom;

    private void Start()
    {
        spawnCounter = timeToSpawn;
    }

    void Update()
    {
        if (playerIsInRoom)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsInRoom = true;
        }
    }
}
