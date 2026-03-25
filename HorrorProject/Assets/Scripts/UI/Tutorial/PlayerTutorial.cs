using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{

    public GameObject walkingTutorial;
    public GameObject crouchingTutorial;
    public GameObject jumpingTutorial;
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
            crouchingTutorial.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchingTutorial.SetActive(false);
            jumpingTutorial.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpingTutorial.SetActive(false);
            playerTutorial.SetActive(false);
        }
    }
}
