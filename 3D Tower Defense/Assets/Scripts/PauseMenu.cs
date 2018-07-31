using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;

    public SceneFader sceneFader;

    public string mainMenuSceneName = "MainMenu";

    public void TogglePauseMenu() {
        GameMaster.isGamePaused = !GameMaster.isGamePaused;
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        if (pauseMenuUI.activeSelf) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    // Resumes the game
    public void Resume() {
        TogglePauseMenu();
    }
    
    // Restarts the current stage
    public void Restart() {
        TogglePauseMenu();
        // Load the current scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // Opens a set of Options
    public void Options() {
        // Add Options menu
    }

    // Brings the player to the main menu
    public void ExitToMainMenu() {
        TogglePauseMenu();
        //SceneManager.LoadScene(mainMenuSceneName);
        sceneFader.FadeTo(mainMenuSceneName);
    }
}
