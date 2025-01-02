using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public CanvasGroup panel; // Reference to the Panel's CanvasGroup component
    public float fadeDuration = 1.0f; // Duration for fade transition
    public AudioSource loadingSound;

    private void Start()
    {
        panel.gameObject.SetActive(false);
        Application.targetFrameRate = 120;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadCaveLevel()
    {
        StartCoroutine(FadeAndLoadScene("Cave_Level"));
    }

    public void LoadForestLevel()
    {
        StartCoroutine(FadeAndLoadScene("Forest_Level"));
    }
    
    public void LoadAnotherLevel()
    {
        StartCoroutine(FadeAndLoadScene("Another_Level"));
    }
    
    public void LoadWinLevel()
    {
        StartCoroutine(FadeAndLoadScene("Win"));
    }

    public void LoadHelpLevel()
    {
        StartCoroutine(FadeAndLoadScene("Help"));
    }

    public void LoadGameOver()
    {
        StartCoroutine(FadeAndLoadScene("GameOver"));
    }

    public void LoadStartMenu()
    {
        StartCoroutine(FadeAndLoadScene("StartMenu"));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        //Reanudes the game if it was paused
        Time.timeScale = 1f;
        panel.gameObject.SetActive(true);
        loadingSound.Play();
        // Fade in (0 to 1)
        yield return StartCoroutine(Fade(0, 1));
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
        
        // Optionally, fade out after loading
        yield return StartCoroutine(Fade(1, 0));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha based on time
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            panel.alpha = newAlpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is set precisely
        panel.alpha = endAlpha;
    }
}