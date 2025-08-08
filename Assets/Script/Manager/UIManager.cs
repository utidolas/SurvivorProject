using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : SingletonPattern<UIManager>
{
    public Slider slider;
    public GameObject DeathPanel;

    // set initial health and max health
    public void SetHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // update health as needed
    public void UpdateHealth(float health)
    {
        slider.value = health;
    }

    // Show the death panel when the player dies
    public void ShowDeathPanel()
    {
        DeathPanel.SetActive(true);
    }

    // Button methods for UI interactions
    public void GoToMainMenu()
    {
        Debug.Log("Go to Main Menu");
    }

    public void GoToSettings()
    {
        Debug.Log("Go to Settings");
    }

    public void RestartGame()
    {
        // Restart the current scene and reset the death panel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        DeathPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
