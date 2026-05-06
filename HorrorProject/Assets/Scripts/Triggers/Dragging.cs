using System.Collections;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public GameObject draggedMan;

    private Animator dragAnimator;
    private AudioSource source;

    public float deletionSeconds;

    private void Start()
    {
        dragAnimator = draggedMan.GetComponent<Animator>();
        source = draggedMan.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            dragAnimator.Play("Dragging");
            StartCoroutine(objectDeletion());
        }
    }

    public IEnumerator objectDeletion()
    {
        yield return new WaitForSeconds(deletionSeconds);
        Destroy(draggedMan);
        Destroy(this.gameObject);
    }
}
