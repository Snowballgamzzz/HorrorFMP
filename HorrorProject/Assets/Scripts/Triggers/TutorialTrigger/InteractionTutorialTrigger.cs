using UnityEngine;

public class InteractionTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    InteractionTutorial tutorial;

    private void Start()
    {
        tutorial = player.GetComponent<InteractionTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorial.interaction = true;
        }
    }
}
