using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Audio;
using NUnit.Framework;
using System.Collections.Generic;

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
    public Dropdown resolutionDropdown;

    [Header("Resolution")]
    Resolution[] resolutions;

    void Start()
    {
        cam = player.GetComponent<FPController>();
        resumeImage = resumeOrPlayButton.GetComponent<Image>();
        backImage = backButton.GetComponent<Image>();
        quitImage = quitButton.GetComponent<Image>();
        optionsImage = optionsButton.GetComponent<Image>();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
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

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
