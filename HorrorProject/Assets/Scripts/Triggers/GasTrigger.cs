using UnityEngine;

public class GasTrigger : MonoBehaviour, IInteractable
{
    private AudioSource audioSource;
    public GameObject audioObject;

    public GameObject gas;
    public GameObject valve;
    ValveController controller;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        controller = valve.GetComponent<ValveController>();
    }

    public void Interact()
    {
        audioSource.Play();
        controller.isGasOn = true;
        gas.SetActive(true);
    }
}
