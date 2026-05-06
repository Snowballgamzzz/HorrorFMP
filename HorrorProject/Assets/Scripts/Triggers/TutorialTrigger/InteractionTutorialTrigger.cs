using UnityEngine;

public class InteractionTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    InteractionTutorial tutorial;
    public bool doOnce;

    private void Start()
    {
        tutorial = player.GetComponent<InteractionTutorial>();
        doOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doOnce)
            {
                tutorial.interaction = true;
                doOnce = true;
            }
        }
    }
}
