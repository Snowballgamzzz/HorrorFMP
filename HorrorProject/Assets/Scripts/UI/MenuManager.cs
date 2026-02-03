using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string LevelName;
    public void StartGame()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
