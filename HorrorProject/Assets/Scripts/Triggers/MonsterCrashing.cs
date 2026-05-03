using UnityEngine;

public class MonsterCrashing : MonoBehaviour
{
    public GameObject bossMonster;

    AudioSource audioSource;
    public GameObject audioObject;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossMonster.SetActive(true);
            audioSource.Play();
        }
    }
}
