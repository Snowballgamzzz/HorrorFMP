using UnityEngine;

public class PauseTutorialTrigger : MonoBehaviour
{
    public GameObject player;
    PauseTutorial tutorial;
    public bool doOnce;

    private void Start()
    {
        tutorial = player.GetComponent<PauseTutorial>();
        doOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doOnce)
            {
                tutorial.pause = true;
                doOnce = true;
            }
        }
    }
}
