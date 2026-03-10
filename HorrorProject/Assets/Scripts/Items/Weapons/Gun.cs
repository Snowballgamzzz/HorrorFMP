using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;

    public int maxAmmo;
    public int maxClip;
    public int currentAmmo;
    public int currentClip;
    public int ammoPerClip;
    public float reloadTime = 1f;

    private bool isReloading = false;

    private float nextTimeToFire = 0f;

    public Camera playerCam;

    FPController controller;

    public TMP_Text AmmoText;
    private string currentAmmoString;
    private string currentClipString;

    void Start()
    {
        controller = GetComponentInParent<FPController>();
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        Mathf.Clamp(currentClip, 0, maxClip);
        Mathf.Clamp(currentAmmo, 0, maxAmmo);

        currentAmmoString = currentAmmo.ToString();
        currentClipString = currentClip.ToString();

        AmmoText.text = currentAmmoString + " / " + currentClipString;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (!controller.isPaused)
        {
            if (isReloading)
            {
                return;
            }

            if (currentAmmo <= 0 && currentClip <= 0)
            {
                StartCoroutine(ReloadTimer());
                return;
            }

            if (context.performed && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                RaycastHit hit;
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
                {
                    Target target = hit.transform.GetComponent<Target>();
                    if (target != null)
                    {
                        target.TakeDamage(damage);
                    }
                }

                currentAmmo--;

            }
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (context.performed && currentClip > 0 && currentAmmo <= maxAmmo)
        {
            StartCoroutine(ReloadTimer());
        }
    }

    private void AmmoCalculation()
    {
        int neededAmmo = maxAmmo - currentAmmo;

        if (currentClip >= maxAmmo)
        {
            currentClip -= neededAmmo;
            currentAmmo += neededAmmo;
        }
        else if (currentClip > 0)
        {
            if (neededAmmo < currentClip)
            {
                currentClip -= neededAmmo;
                currentAmmo += neededAmmo;
            }
            else
            {
                currentAmmo += currentClip;
                currentClip = 0;
            }
        }
    }

    IEnumerator ReloadTimer()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        AmmoCalculation();

        isReloading = false;
    }
}
