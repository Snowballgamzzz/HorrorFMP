using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kidnap : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject carObjectOne;
    public GameObject carObjectTwo;
    public GameObject person;
    public GameObject blood;
    public GameObject streetLight;
    public GameObject player;
    public GameObject bloodDialogue;
    public GameObject lightDialogue;
    public GameObject blackOut;

    [Header("Floats")]
    public float triggerSeconds;

    [Header("Strings")]
    public string LevelName;

    void Start()
    {
        carObjectOne.SetActive(false);
        carObjectTwo.SetActive(false);
        person.SetActive(false);
        blackOut.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FPController>().movementSpeed = 0f;
            other.GetComponent<FPController>().mouseSensitivity = 0f;

            StartCoroutine(trigger());
        }
    }

    public IEnumerator trigger()
    {
        player.transform.LookAt(blood.transform);
        bloodDialogue.SetActive(true);

        yield return new WaitForSeconds(triggerSeconds);
        bloodDialogue.SetActive(false);
        streetLight.SetActive(false);
        player.transform.LookAt(streetLight.transform);
        lightDialogue.SetActive(true);

        yield return new WaitForSeconds(triggerSeconds);
        lightDialogue.SetActive(false);
        carObjectOne.SetActive(true);
        carObjectTwo.SetActive(true);
        person.SetActive(true);
        player.transform.LookAt(person.transform);

        yield return new WaitForSeconds(triggerSeconds);
        blackOut.SetActive(true);

        yield return new WaitForSeconds(triggerSeconds);
        SceneManager.LoadScene(LevelName);

    }
}
