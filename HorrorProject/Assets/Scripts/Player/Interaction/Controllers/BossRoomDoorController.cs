using UnityEngine;
using System.Collections;

public class BossRoomDoorController : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private bool isDoorOpen = false;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!pauseInteraction && !isDoorOpen)
        { 
        StartCoroutine(ShowDoorLocked());
        StartCoroutine(PauseDoorInteraction());
        }
    }

    public void OpenDoor()
    {
        doorAnim.Play("DoorOpen", 0, 0.0f);
        isDoorOpen = true;
    }

    IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
