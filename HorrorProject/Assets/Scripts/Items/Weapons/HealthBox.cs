using System.Collections;
using UnityEngine;

public class HealthBox : MonoBehaviour, IInteractable
{
    public GameObject player;
    PlayerHealth health;

    public GameObject healthFullUI;
    public int timeToShowUI = 1;

    void Start()
    {
        health = player.GetComponent<PlayerHealth>();
    }

    public void Interact()
    {
        if (health.health < health.maxHealth)
        { 
            health.Heal();
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(ShowHealthFull());
        }
    }

    IEnumerator ShowHealthFull()
    {
        healthFullUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        healthFullUI.SetActive(false);
    }
}
