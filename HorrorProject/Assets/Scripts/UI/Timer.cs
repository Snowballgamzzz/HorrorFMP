using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.UI;

public class Timer : MonoBehaviour
{
    public float gameObjectTImer;

    public void StartTimer()
    {
        StartCoroutine(disableGameObject());
    }

    private IEnumerator disableGameObject()
    {
        yield return new WaitForSeconds(gameObjectTImer);
        this.gameObject.SetActive(false);
    }
}
