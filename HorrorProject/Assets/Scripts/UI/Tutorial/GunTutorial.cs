using System.Collections;
using UnityEngine;

public class GunTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public float tutorialUISeconds;

    public IEnumerator showGunTutorial()
    {
        tutorialUI.SetActive(true);
        yield return new WaitForSeconds(tutorialUISeconds);
        tutorialUI.SetActive(false);
    }
}
