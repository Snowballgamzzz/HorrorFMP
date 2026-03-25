using UnityEngine;
using System.Collections;

public class FlashlightTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public float tutorialUISeconds;

    public IEnumerator showFlashLightTutorial()
    {
        tutorialUI.SetActive(true);
        yield return new WaitForSeconds(tutorialUISeconds);
        tutorialUI.SetActive(false);
    }
}
