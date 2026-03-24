using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    //public int amountToChangeStat;

    private HealthManager healthManager;
    private AmmoManager ammoManager;
    private Inventory inventory;

    public bool UseItem()
    {
        if (statToChange == StatToChange.health)
        {
            healthManager = GameObject.Find("Health Manager").GetComponent<HealthManager>();

            //Add a check to see if the player can heal
            if (healthManager.health.health == healthManager.health.maxHealth)
            {
                //If health is already full return false
                healthManager.ShowHealthUI();
                return false;
            }
            else if (healthManager.health.health < healthManager.health.maxHealth)
            {
                //else player heals and return true
                healthManager.health.Heal();
                return true;
            }
        }
        else if (statToChange == StatToChange.ammo)
        {
            //Add a check to see if the player can add ammo to the clip
            ammoManager = GameObject.Find("Ammo Manager").GetComponent<AmmoManager>();

            if (ammoManager.playerGun.currentClip < ammoManager.playerGun.maxClip)
            {
                int additionalAmmo = Random.Range(1, 10);
                ammoManager.playerGun.currentClip += additionalAmmo;
                return true;
            }
            else
            {
                ammoManager.ShowAmmoUI();
                return false;
            }
        }
        else if (statToChange == StatToChange.doorKey)
        {
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

            if (inventory.hasKey)
            {
                return true;
            }
            else if (!inventory.hasKey)
            {
                return false;
            }
        }

            return false;
    }

    public enum StatToChange
    { 
        none,
        health,
        doorKey,
        ammo
    };

}
