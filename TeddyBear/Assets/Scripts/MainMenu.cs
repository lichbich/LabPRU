using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [Header("UI")]
    public GameObject mainMenuPanel;   // kéo MainMenuPanel vào đây
    public GameObject levelPanel;      // kéo LevelPanel vào đây

    void Start()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelPanel != null) levelPanel.SetActive(false);
    }

    // Khi nhấn Play
    public void Play()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (levelPanel != null) levelPanel.SetActive(true);
    }

    // Khi nhấn Back trong LevelPanel
    public void BackToMenu()
    {
        if (levelPanel != null) levelPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }

    // Load Level bằng index
    public void LoadLevelByIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void OpenIntroduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
