using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IInteractable
{
    public GameObject endingScreen;
    public GameObject showEnemyLiveUI;
    public GameObject enemy;

    public bool isEnemyDead;

    EnemyAgent agent;

    private void Start()
    {
        agent = enemy.GetComponent<EnemyAgent>();
    }

    private void Update()
    {
        if (agent.config.enemyHealth <= 0)
        {
            isEnemyDead = true;
        }
    }

    public void Interact()
    {
        if (isEnemyDead)
        {
            endingScreen.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowEnemyHealth());
        }
    }

    IEnumerator ShowEnemyHealth()
    {
        showEnemyLiveUI.SetActive(true);
        yield return new WaitForSeconds(1);
        showEnemyLiveUI.SetActive(false);
    }
}
