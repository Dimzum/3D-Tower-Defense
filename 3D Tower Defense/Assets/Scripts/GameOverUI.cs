using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public SceneFader sceneFader;

    // Restarts the game from stage 1
    public void Retry() {
        //SceneManager.LoadScene(stageOneSceneName);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // Brings the player to the main menu
    public void MainMenu() {
        //SceneManager.LoadScene(mainMenuSceneName);
        sceneFader.FadeTo(SceneFader.mainMenuSceneName);
    }

    // Quits the application
    public void Quit() {
        // For use in editor
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        Application.Quit();
    }
}
