using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public bool UseItem()
    {
        if (statToChange == StatToChange.health)
        {
            //Add a check to see if the player can heal
            //If health is already full return false
            //else player heals and return true
        }
        if (statToChange == StatToChange.ammo)
        {
            //Add a check to see if the player can add ammo to the clip
        }

        return false;
    }

    public enum StatToChange
    { 
        none,
        health,
        ammo
    };

}
