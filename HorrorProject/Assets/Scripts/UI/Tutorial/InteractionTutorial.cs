using UnityEngine;

public class InteractionTutorial : MonoBehaviour
{
    public GameObject interactionTutorial;
    public GameObject playerTutorial;

    public bool interaction;

    private void Start()
    {
        interaction = false;
        interactionTutorial.SetActive(false);
        playerTutorial.SetActive(false);
    }

    private void Update()
    {
        if (interaction)
        {
            interactionTutorial.SetActive(true);
            playerTutorial.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            interactionTutorial.SetActive(false);
            playerTutorial.SetActive(false);
            interaction = false;
        }
    }
}
