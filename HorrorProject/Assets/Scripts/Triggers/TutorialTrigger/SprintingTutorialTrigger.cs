using UnityEngine;

public class SprintingTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    SprintingTutorial tutorial;
    public bool doOnce;

    private void Start()
    {
        tutorial = player.GetComponent<SprintingTutorial>();
        doOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doOnce)
            {
                tutorial.sprinting = true;
                doOnce = true;
            }
        }
    }
}
