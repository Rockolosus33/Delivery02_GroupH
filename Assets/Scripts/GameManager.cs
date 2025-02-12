using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        PlayerWin.OnPlayerWin += EndScene;
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
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