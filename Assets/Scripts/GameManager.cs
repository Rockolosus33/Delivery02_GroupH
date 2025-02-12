using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;

    private System.Collections.IEnumerator WaitForSoundAndChangeScene()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("Gameplay");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerWin.OnPlayerWin += EndScene;
    }

    public void Play()
    {
        audioSource.Play();
        StartCoroutine(WaitForSoundAndChangeScene());
    }

    private void EndScene()
    {
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