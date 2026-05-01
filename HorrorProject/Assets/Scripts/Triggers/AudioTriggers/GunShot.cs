using System.Collections;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject audioGunObject;
    private AudioSource audioGunSource;

    public GameObject audioScreamObject;
    private AudioSource audioScreamSource;

    public float timeBetweenAudio;

    public bool doOnce;

    private void Start()
    {
        audioGunSource = audioGunObject.GetComponent<AudioSource>();
        audioScreamSource = audioScreamObject.GetComponent<AudioSource>();
        doOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doOnce)
            {
                doOnce = true;
                StartCoroutine(Audio());
            }
        }
    }

    IEnumerator Audio()
    {
        audioScreamSource.Play();
        yield return new WaitForSeconds(timeBetweenAudio);
        audioGunSource.Play();
    }
}
