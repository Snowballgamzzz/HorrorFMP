using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject audioObject;

    public GameObject brokenWindow;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        brokenWindow.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        brokenWindow.SetActive(true);
    }
}
