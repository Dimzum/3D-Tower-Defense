using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    // Static variables for scene names
    public static string mainMenuSceneName = "MainMenu";
    public static string gameModeSelectSceneName = "GameModeSelect";
    public static string levelSelectSceneName = "LevelSelect";
    public static string level01SceneName = "Level01";
    public static string level02SceneName = "Level02";
    public static string level03SceneName = "Level03";

    public Image img;
    public AnimationCurve curve;

    private float fadeInSpeed = .5f;
    private float fadeOutSpeed = .75f;

    private void Start() {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() {
        float t = 1f;

        while (t > 0f) {
            t -= Time.deltaTime * fadeInSpeed;
            float alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);

            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime * fadeOutSpeed;
            float alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);

            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
