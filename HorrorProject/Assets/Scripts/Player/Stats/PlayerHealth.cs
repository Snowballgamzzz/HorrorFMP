using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //[Range(0f, 100f)]
    public float health;
    public float maxHealth;

    public Slider healthBar;

    public float healAmount;

    public string levelLoad;

    private void Start()
    {
        healthBar.value = health; 
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(levelLoad);
        }
    }

    public void Heal()
    {
        healAmount = Random.Range(10, 20);
        health += healAmount;
        healthBar.value = health;
    }
}
