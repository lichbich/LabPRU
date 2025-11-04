using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject winUI;

    private int bearCount;

    void Awake()
    {
        // Singleton đơn giản
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Ẩn Win UI
        if (winUI != null) winUI.SetActive(false);

        // Đếm số gấu lúc bắt đầu
        bearCount = GameObject.FindGameObjectsWithTag("Bear").Length;
        Debug.Log("Bear count at start: " + bearCount);
    }

    // Gọi khi 1 con gấu chết
    public void BearDied()
    {
        bearCount--;
        Debug.Log("Bear died. Remaining: " + bearCount);

        if (bearCount <= 0)
        {
            WinLevel();
        }
    }

    public void WinLevel()
    {
        // Pause game (physics/Update), UI vẫn phản hồi
        Time.timeScale = 0f;
        if (winUI != null) winUI.SetActive(true);
    }

    // UI button handlers (kéo GameManager object vào button OnClick và chọn method)
    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene("MainMenu"); // hoặc quay menu nếu hết level
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
