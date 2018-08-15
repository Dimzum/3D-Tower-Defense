using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSelect : MonoBehaviour {

    public SceneFader sceneFader;

    public void StoryMode() {
        sceneFader.FadeTo(SceneFader.levelSelectSceneName);
    }

    public void EndlessMode() {
        Debug.Log("ENDLESS MODE!");
    }
}
