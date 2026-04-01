using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{

    public GameObject walkingTutorial;
    public GameObject crouchingTutorial;
    public GameObject jumpingTutorial;
    public GameObject interactionTutorial;
    public GameObject shootingTutorial;
    public GameObject inventoryTutorial;
    public GameObject playerTutorial;

    private bool walking;
    private bool crouching;
    private bool jumping;
    private bool interaction;
    private bool shooting;
    private bool inventory;

    private void Start()
    {
        walkingTutorial.SetActive(true);
        walking = true;
        crouching = false;
        jumping = false;
        interaction = false;
        shooting = false;
        inventory = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && walking || Input.GetKey(KeyCode.A) && walking || Input.GetKeyDown(KeyCode.S) && walking || Input.GetKeyDown(KeyCode.D) && walking) 
        {
            walkingTutorial.SetActive(false);
            walking = false;
            crouchingTutorial.SetActive(true);
            crouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && crouching)
        {
            crouchingTutorial.SetActive(false);
            crouching = false;
            jumpingTutorial.SetActive(true);
            jumping = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumping)
        {
            jumpingTutorial.SetActive(false);
            jumping = false;
            interactionTutorial.SetActive(true);
            interaction = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            interactionTutorial.SetActive(false);
            interaction = false;
            shootingTutorial.SetActive(true);
            shooting = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && shooting)
        {
            shootingTutorial.SetActive(false);
            shooting = false;
            inventoryTutorial.SetActive(true);
            inventory = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventory)
        {
            inventoryTutorial.SetActive(false);
            inventory = false;
            playerTutorial.SetActive(false);
        }
    }
}
