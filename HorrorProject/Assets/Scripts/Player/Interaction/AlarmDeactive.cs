using UnityEngine;
using System.Collections.Generic;

public class AlarmDeactive : MonoBehaviour, IInteractable
{
    public List<GameObject> objects;
    private int currentDeactiveIndex = 0;

    public void Interact()
    {
        Debug.Log("YAY");
        objects[currentDeactiveIndex].SetActive(false);
    }
}
