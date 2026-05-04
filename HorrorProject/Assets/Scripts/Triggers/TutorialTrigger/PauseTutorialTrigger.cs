using UnityEngine;

public class PauseTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    PauseTutorial tutorial;

    private void Start()
    {
        tutorial = player.GetComponent<PauseTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorial.pause = true;
        }
    }
}
