using System.Collections;
using UnityEngine;

public class BlockedDoorController : MonoBehaviour, IInteractable
{
    public bool isDoorBlocked;
    public bool isDoorOpen;
    private bool pauseInteraction = false;

    private Animator doorAnim;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private int waitTimer = 1;

    [SerializeField] private GameObject showDoorBlockedUI = null;

    private void Start()
    {
        doorAnim = GetComponent<Animator>();
        isDoorBlocked = true;
    }

    public void Interact()
    {
        if (!isDoorBlocked && !pauseInteraction)
        {
            if (!isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorOpen");
                isDoorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
            else if (isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorClose");
                isDoorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
        else if (isDoorBlocked)
        {
            StartCoroutine(ShowDoorBlocked());
        }
    }

    IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    IEnumerator ShowDoorBlocked()
    {
        showDoorBlockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorBlockedUI.SetActive(false);
    }
}
