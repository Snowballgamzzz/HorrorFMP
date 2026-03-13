using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //[Range(0f, 100f)]
    public float health;
    public float maxHealth;

    public Slider healthBar;

    public float healAmount;

    private void Start()
    {
        healthBar.value = health; 
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is Dead");
        }
    }

    public void Heal()
    {
        healAmount = Random.Range(10, 20);
        health += healAmount;
        healthBar.value = health;
    }
}
