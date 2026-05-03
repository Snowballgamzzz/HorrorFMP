using UnityEngine;
using System.Collections.Generic;

public class AlarmDeactive : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> objects;
    public void Interact()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
