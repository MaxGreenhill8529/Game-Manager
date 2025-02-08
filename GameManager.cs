using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Death Screen Settings")]
    [SerializeField] private CanvasGroup deathScreen;
    [SerializeField] private float fadeInTime;
    [Header("Audio Settings")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private float fadeOutTime = 1f;

    private static float originalTimeScale;
    public void ShowDeathScreen()
    {
        if(deathScreen.alpha > 0)
        {
            Debug.LogWarning("Death Screen is already visible, returning out of function call.");
            return;
        }
        StartCoroutine(Effects.Fade(deathScreen, FadeMode.IN,fadeInTime, true));
        StartCoroutine(Effects.Fade(backgroundMusic, FadeMode.OUT, fadeOutTime / 2,true));
    }

    public static void ShowCanvasGroup(CanvasGroup canvasGroup)
    {
        if (canvasGroup.alpha > 0)
        {
            Debug.LogWarning("Canvas Group is already visible, returning out of function call.");
            return;
        }
        canvasGroup.alpha = 1;
    }

    /// <summary>
    /// Sets Time.timeScale to 0
    /// </summary>
    public static void PauseTime()
    {
        originalTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Sets the time.timeScale variable to what it previously was before it was set to 0
    /// </summary>
    public static void ResumeTime()
    {
        Time.timeScale = originalTimeScale;
    }

    /// <summary>
    /// Reloads the current scene
    /// </summary>
    public static void ReloadScene()
    {
        string name = SceneManager.GetActiveScene().name;
        Debug.Log("Reloading scene: " + name);
        SceneManager.LoadSceneAsync(name);
    }

    /// <summary>
    /// Loads the scene with a given name
    /// </summary>
    /// <param name="name"></param>
    public static void LoadScene(string name)
    {
        Debug.Log("Loading scene: " + name);
        SceneManager.LoadSceneAsync(name);
    }
}
