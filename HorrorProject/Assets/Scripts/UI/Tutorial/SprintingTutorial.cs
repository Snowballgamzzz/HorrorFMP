using UnityEngine;

public class SprintingTutorial : MonoBehaviour
{
    public GameObject sprintingTutorial;
    public GameObject playerTutorial;

    public bool sprinting;

    private void Start()
    {
        sprinting = false;
        sprintingTutorial.SetActive(false);
    }

    private void Update()
    {
        if (sprinting)
        {
            sprintingTutorial.SetActive(true);
            playerTutorial.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && sprinting)
        {
            sprintingTutorial.SetActive(false);
            playerTutorial.SetActive(false);
            sprinting = false;
        }
    }
}
