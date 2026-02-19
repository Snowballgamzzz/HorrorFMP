using System.Collections;
using UnityEngine;

public class KeyDoorController : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private bool isDoorOpen = false;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [SerializeField] private Inventory inventory = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (inventory.hasKey)
        {
            if (!isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorOpen", 0, 0.0f);
                isDoorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
            else if (isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorClose", 0, 0.0f);
                isDoorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
        else
        {
            StartCoroutine(ShowDoorLocked());
        }
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
