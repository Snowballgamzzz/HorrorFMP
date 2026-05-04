using UnityEngine;

public class PauseTutorial : MonoBehaviour
{
    public GameObject pauseTutorial;
    public GameObject playerTutorial;

    public bool pause;

    private void Start()
    {
        pause = false;
        pauseTutorial.SetActive(false);
    }

    private void Update()
    {
        if (pause)
        {
            playerTutorial.SetActive(true);
            pauseTutorial.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            pauseTutorial.SetActive(false);
            playerTutorial.SetActive(false);
            pause = false;
        }
    }
}
