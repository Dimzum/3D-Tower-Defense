using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public SceneFader sceneFader;

    public string mainMenuSceneName = "MainMenu";
    public string stageOneSceneName = "Stage_1";

    public Text roundsText;

    private void OnEnable() {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    // Restarts the game from stage 1
    public void PlayAgain() {
        //SceneManager.LoadScene(stageOneSceneName);
        sceneFader.FadeTo(stageOneSceneName);
    }

    // Brings the player to the main menu
    public void MainMenu() {
        //SceneManager.LoadScene(mainMenuSceneName);
        sceneFader.FadeTo(mainMenuSceneName);
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
