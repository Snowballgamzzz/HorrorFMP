using System.Collections;
using UnityEngine;

public class InventoryTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public float tutorialUISeconds;

    public IEnumerator showInventoryTutorial()
    {
        tutorialUI.SetActive(true);
        yield return new WaitForSeconds(tutorialUISeconds);
        tutorialUI.SetActive(false);
    }
}
