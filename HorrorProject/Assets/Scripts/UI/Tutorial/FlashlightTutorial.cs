using UnityEngine;
using System.Collections;

public class FlashlightTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public float tutorialUISeconds;

    InventoryTutorial tutorial;

    private void Start()
    {
        tutorial = GetComponent<InventoryTutorial>();
    }

    public IEnumerator showFlashLightTutorial()
    {
        tutorialUI.SetActive(true);
        yield return new WaitForSeconds(tutorialUISeconds);
        tutorialUI.SetActive(false);
        StartCoroutine(tutorial.showInventoryTutorial());
    }
}
