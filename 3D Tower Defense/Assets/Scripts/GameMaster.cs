using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    public GameObject gameOverUI;
    public GameObject levelCompleteUI;

    public PauseMenu pauseMenu;

    public static bool isGameOver;
    public static bool isGamePaused;

    private void Start() {
        isGamePaused = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update () {
        if (isGameOver) { return; }
        
        // Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            pauseMenu.TogglePauseMenu();
        }

        if (PlayerStats.Health <= 0) {
            EndGame();
        }
	}

    public void EndGame() {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void LevelComplete() {
        isGameOver = true;
        levelCompleteUI.SetActive(true);
    }
}
