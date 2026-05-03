using UnityEngine;

public class GunSpawn : MonoBehaviour, IInteractable
{
    public GameObject weaponObject;

    private void Start()
    {
        weaponObject.SetActive(false);
    }

    public void Interact()
    {
        weaponObject.SetActive(true);
    }
}
