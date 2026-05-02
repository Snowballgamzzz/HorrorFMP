using UnityEngine;

public class GlassBreaking : MonoBehaviour
{
    public GameObject audioObject;
    private AudioSource audioSource;

    public bool doOnce;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        doOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doOnce)
            {
                audioSource.Play();
                doOnce = true;
            }
        }
    }
}
