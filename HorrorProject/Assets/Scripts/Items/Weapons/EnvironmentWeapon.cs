using UnityEngine;

public class EnvironmentWeapon : MonoBehaviour, IInteractable
{
    public GameObject environmentGun;
    public GameObject ammoCount;
    public GameObject playerGun;

    Gun gun;

    private void Start()
    {
        gun = playerGun.GetComponent<Gun>();
        ammoCount.SetActive(false);
        playerGun.SetActive(false);
    }

    public void Interact()
    {
        gun.doesPlayerHaveGun = true;
        playerGun.SetActive(true);
        ammoCount.SetActive(true);
        Destroy(environmentGun);
    }
}
