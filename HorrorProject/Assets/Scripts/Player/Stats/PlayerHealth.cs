using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //[Range(0f, 100f)]
    public float health;
    public float maxHealth;

    public Slider healthBar;

    public float healAmount;

    public string levelLoad;

    public Transform respawnPoint;
    public Transform player;

    public GameObject deathUI;
    CharacterController characterController;

    private void Start()
    {
        healthBar.value = health;
        player = this.gameObject.transform;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            deathUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            characterController.enabled = false;
        }
    }

    public void Heal()
    {
        healAmount = Random.Range(10, 20);
        health += healAmount;
        healthBar.value = health;
    }

    public void Respawn()
    {
        player.transform.position = respawnPoint.position;
        health = maxHealth;
        deathUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController.enabled = true;
    }
}
