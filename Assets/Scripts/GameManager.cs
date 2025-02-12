using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static bool playerHasWon = false;

    private System.Collections.IEnumerator WaitForSoundAndChangeScene()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("Gameplay");
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerWin.OnPlayerWin += WinEndScene;
        VisionDetector.OnChangeFinalScene += LoseEndScene;
    }

    private void OnDisable()
    {
        PlayerWin.OnPlayerWin -= WinEndScene;
        VisionDetector.OnChangeFinalScene -= LoseEndScene;
    }

    public void Play()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            StartCoroutine(WaitForSoundAndChangeScene());
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    private void WinEndScene()
    {
        playerHasWon = true;
        SceneManager.LoadScene("Ending");
    }

    private void LoseEndScene()
    {
        playerHasWon = false;
        SceneManager.LoadScene("Ending");
    }

    void OnEnter()
    {
        Play();
    }

    void OnExit()
    {
        Application.Quit();
    }
}