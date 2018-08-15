using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMaster : MonoBehaviour {

    public SceneFader sceneFader;

    // Start the Game - load stage 1
	public void Play() {
        sceneFader.FadeTo(SceneFader.gameModeSelectSceneName);
    }

    // Instructions and controls for the player
    public void HowToPlay() {
        //Add a scene or a canvas for instuctions and controls
        Debug.Log("How To Play!");
    }

    // Settings menu where the player can change settings <--- Settings that go in this menu are TBD
    public void Settings() {
        //Add a scene or a canvas for settings
        Debug.Log("Settings!");
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
