using UnityEngine;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
    public GameObject playerWeapon;
    public GameObject ammoFullUI;
    public Gun playerGun;

    public int timeToShowUI = 1;

    void Start()
    {
        playerGun = playerWeapon.GetComponent<Gun>();
    }

    public void ShowAmmoUI()
    {
        StartCoroutine(ShowAmmoFull());
    }

    IEnumerator ShowAmmoFull()
    {
        ammoFullUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        ammoFullUI.SetActive(false);
    }
}
