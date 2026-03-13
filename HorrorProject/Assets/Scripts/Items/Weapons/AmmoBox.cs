using System.Collections;
using UnityEngine;

public class AmmoBox : MonoBehaviour, IInteractable
{
    public GameObject playerWeapon;
    public GameObject ammoFullUI;
    Gun playerGun;

    public int timeToShowUI = 1;

    void Start()
    {
        playerGun = playerWeapon.GetComponent<Gun>();
    }

    public void Interact()
    {
        if (playerGun.currentClip < playerGun.maxClip)
        {
            int additionalAmmo = Random.Range(1, 10);
            playerGun.currentClip += additionalAmmo;
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowAmmoFull());
        }
    }

    IEnumerator ShowAmmoFull()
    {
        ammoFullUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        ammoFullUI.SetActive(false);
    }
}
