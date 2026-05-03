using UnityEngine;

public class MonsterSpawn : MonoBehaviour, IInteractable
{
    public GameObject tutorialEnemy;

    private void Start()
    {
        tutorialEnemy.SetActive(false);
    }

    public void Interact()
    {
        tutorialEnemy.SetActive(true);
    }
}
