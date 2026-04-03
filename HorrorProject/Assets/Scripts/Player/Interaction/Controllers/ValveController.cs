using UnityEngine;

public class ValveController : MonoBehaviour, IInteractable
{
    public GameObject gas;

    public void Interact()
    {
        gas.SetActive(false);
    }
}
