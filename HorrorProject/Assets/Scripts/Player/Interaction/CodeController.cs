using UnityEngine;

public class CodeController : MonoBehaviour
{
    private InteractionController anim;
    public GameObject door;

    private void Start()
    {
        anim = door.GetComponent<InteractionController>();
    }

    public void PlayAnim()
    {
        anim.PlayAnimation();
    }
}
