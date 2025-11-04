using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có dòng này để quản lý Scene

public class MenuController : MonoBehaviour
{
    // Function để gọi khi bấm nút AirPlane
    public void StartLoadLevelScene()
    {
        // Tải scene có tên là "SampleScene"
        SceneManager.LoadScene("LevelScene");
    }
    public void Setting()
    {
        // Tải scene có tên là "SampleScene"
        SceneManager.LoadScene("Setting");
    }
    
    public void AboutUs()
    {
        // Tải scene có tên là "SampleScene"
        SceneManager.LoadScene("AboutUs");
    }

    // Function để gọi khi bấm nút AirPlane
    public void LoadAirPlaneScene()
    {
        // Tải scene có tên là "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }

    // Function để gọi khi bấm nút Boxing
    public void LoadBoxingScene()
    {
        // Tải scene có tên là "Dance"
        SceneManager.LoadScene("Dance");
    }

    public void BackToMenu()
    {
        // Tải scene có tên là "Dance"
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Ghi log để kiểm tra trong Editor
        Debug.Log("Đã nhấn nút Quit!");
        Application.Quit();
    }
}