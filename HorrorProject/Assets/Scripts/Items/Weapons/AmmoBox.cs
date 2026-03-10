using UnityEngine;

public class AmmoBox : MonoBehaviour, IInteractable
{
    public GameObject playerWeapon;
    //public GameObject ammoFullUI;
    Gun playerGun;

    void Start()
    {
        playerGun = playerWeapon.GetComponent<Gun>();
    }

    public void Interact()
    {
        int additionalAmmo = Random.Range(1, 10);
        playerGun.currentClip += additionalAmmo;
        gameObject.SetActive(false);
    }
}
