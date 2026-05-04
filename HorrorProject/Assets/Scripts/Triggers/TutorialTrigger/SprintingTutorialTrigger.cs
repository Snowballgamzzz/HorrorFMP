using UnityEngine;

public class SprintingTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    SprintingTutorial tutorial;

    private void Start()
    {
        tutorial = player.GetComponent<SprintingTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorial.sprinting = true;
        }
    }
}
