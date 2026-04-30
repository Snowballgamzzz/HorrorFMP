using System.Collections;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public GameObject draggedMan;

    private Animator dragAnimator;

    public float deletionSeconds;

    private void Start()
    {
        dragAnimator = draggedMan.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
