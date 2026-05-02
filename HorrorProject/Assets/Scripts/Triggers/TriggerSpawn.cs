using UnityEngine;

public class TriggerSpawn : MonoBehaviour, IInteractable
{
    public GameObject triggerObject;

    private void Start()
    {
        triggerObject.SetActive(false);
    }

    public void Interact()
    {
        triggerObject.SetActive(true);
    }
}
