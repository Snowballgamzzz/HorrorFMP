using UnityEngine;

public class Monster : MonoBehaviour, IInteractable
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        audioSource.Play();
    }
}
