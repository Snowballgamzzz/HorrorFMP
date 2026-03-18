using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth health;

    public GameObject healthFullUI;
    public int timeToShowUI = 1;

    void Start()
    {
        health = player.GetComponent<PlayerHealth>();
    }

    public void ShowHealthUI()
    {
        StartCoroutine(ShowHealthFull());
    }

    IEnumerator ShowHealthFull()
    {
        healthFullUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        healthFullUI.SetActive(false);
    }
}
