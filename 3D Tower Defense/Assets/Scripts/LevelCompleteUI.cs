using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour {

    public SceneFader sceneFader;
    
    public string nextLevel = "Level02";
    public int levelToUnlock = 1;
    private int lastLevel = 3;

    private void OnEnable() {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);

        if (levelToUnlock + 1 > lastLevel) {
            Debug.Log("LAST LEVEL COMPLETED");
        } else {
            nextLevel = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex).name;
            levelToUnlock++;
        }
    }

    public void NextLevel() {
        sceneFader.FadeTo(SceneFader.levelSelectSceneName);
    }

    public void LevelSelect() {
        sceneFader.FadeTo(SceneFader.levelSelectSceneName);
    }

    public void MainMenu() {
        sceneFader.FadeTo(SceneFader.mainMenuSceneName);
    }
}
