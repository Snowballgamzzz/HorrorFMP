using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string LevelName;
    public GameObject player;
    public GameObject pauseMenuCanvas;
    public static bool paused = false;

    public Sprite resumeSprite;
    public Sprite backSprite;
    public Sprite quitSprite;
    public Sprite optionsSprite;

    private Image resumeImage;
    private Image backImage;
    private Image quitImage;
    private Image optionsImage;

    public GameObject resumeOrPlayButton;
    public GameObject backButton;
    public GameObject quitButton;
    public GameObject optionsButton;

    FPController cam;

    void Start()
    {
        cam = player.GetComponent<FPController>();
        resumeImage = resumeOrPlayButton.GetComponent<Image>();
        backImage = backButton.GetComponent<Image>();
        quitImage = quitButton.GetComponent<Image>();
        optionsImage = optionsButton.GetComponent<Image>();
    }

    public void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed && !cam.isAtKeypad && !cam.isAtPC)
        {
            if (paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);
        paused = true;
        cam.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.mouseSensitivity = 0f;
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);
        paused = false;
        cam.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.mouseSensitivity = 3f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelName);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSprite()
    {
        resumeImage.sprite = resumeSprite;
        backImage.sprite = backSprite;
        quitImage.sprite = quitSprite;
        optionsImage.sprite = optionsSprite;
    }
}
