using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    EnemyController controller;
    public GameObject tutorialEnemy;

    [SerializeField] private List<EnemySpawner> spawners;

    private void Start()
    {
        controller = tutorialEnemy.GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (controller.enemyHealth == 0f)
        {
            foreach (var obj in spawners)
            {
                obj.canSpawn = true;
            }
        }
    }
}
