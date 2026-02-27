using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is Dead");
        }
    }
}
