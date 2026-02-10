using System.Collections;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public enum InteractionTypeController
    {
        Safe,
        DoorWithKey,
        DoorWithNoKey
    }

    public InteractionTypeController typeController;

    private Animator doorAnim;
    private bool doorOpen = false;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [SerializeField] private Inventory inventory = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (!doorOpen && typeController == InteractionTypeController.DoorWithNoKey)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else if (doorOpen && typeController == InteractionTypeController.DoorWithNoKey)
        {
            doorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }


        if (typeController == InteractionTypeController.DoorWithKey)
        {
            if (inventory.hasKey)
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorAnim.Play("DoorOpen", 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play("DoorClose", 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        if (typeController == InteractionTypeController.Safe)
        {
            if (!doorOpen)
            {
                doorAnim.Play("SafeOpen", 0, 0.0f);
                doorOpen = true;
            }
        }
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
