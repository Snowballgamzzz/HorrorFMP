using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public string LevelName;
    public static bool paused = false;

    [Header("Sprites")]
    public Sprite resumeSprite;
    public Sprite backSprite;
    public Sprite quitSprite;
    public Sprite optionsSprite;

    [Header("Images")]
    private Image resumeImage;
    private Image backImage;
    private Image quitImage;
    private Image optionsImage;

    [Header("GameObjects")]
    public GameObject resumeOrPlayButton;
    public GameObject backButton;
    public GameObject quitButton;
    public GameObject optionsButton;
    public GameObject healthBar;
    public GameObject ammo;
    public GameObject player;
    public GameObject pauseMenuCanvas;

    FPController cam;

    [Header("Audio")]
    public AudioMixer audioMixer;

    [Header("Dropdown")]
    public TMP_Dropdown resolutionDropdown;

    [Header("Resolution")]
    private Resolution[] resolutions;
    int SelectedResolution;

    void Start()
    {
        cam = player.GetComponent<FPController>();
        resumeImage = resumeOrPlayButton.GetComponent<Image>();
        backImage = backButton.GetComponent<Image>();
        quitImage = quitButton.GetComponent<Image>();
        optionsImage = optionsButton.GetComponent<Image>();

        resolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();

        foreach (Resolution res in resolutions)
        {
            resolutionStringList.Add(res.ToString());
        }

        resolutionDropdown.AddOptions(resolutionStringList);
    }

    public void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed && !cam.isAtKeypad && !cam.isAtPC && !cam.isInspectingDocument)
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
        healthBar.SetActive(false);
        ammo.SetActive(false);
        paused = true;
        cam.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.mouseSensitivity = 0f;
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);
        healthBar.SetActive(true);
        ammo.SetActive(true);
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
