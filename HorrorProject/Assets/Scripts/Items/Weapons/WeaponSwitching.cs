using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    public GameObject pistolAmmoCount;
    public GameObject shotgunAmmoCount;
    public GameObject meleeAmmoCount;

    private void Start()
    {
        SelectedWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
            AmmoSwitch();
        }
    }

    void AmmoSwitch()
    {
        if (selectedWeapon == 0)
        {
            meleeAmmoCount.SetActive(true);
            pistolAmmoCount.SetActive(false);
            shotgunAmmoCount.SetActive(false);
        }
        else if (selectedWeapon == 1)
        {
            meleeAmmoCount.SetActive(false);
            pistolAmmoCount.SetActive(true);
            shotgunAmmoCount.SetActive(false);
        }
        if (selectedWeapon == 2)
        {
            meleeAmmoCount.SetActive(false);
            pistolAmmoCount.SetActive(false);
            shotgunAmmoCount.SetActive(true);
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
