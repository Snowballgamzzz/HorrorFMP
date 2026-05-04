using UnityEngine;

public class WalkingTutorial : MonoBehaviour
{
    public GameObject walkingTutorial;
    public GameObject playerTutorial;

    private void Start()
    {
        walkingTutorial.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            walkingTutorial.SetActive(false);
            playerTutorial.SetActive(false);
        }
    }
}
