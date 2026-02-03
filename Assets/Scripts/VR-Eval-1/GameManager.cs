using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public bool isGamePaused = false;
    public bool isGameOver = false;

    [Header("Events")]
    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameResume;
    public UnityEvent OnGameOver;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame() {
        Debug.Log("Start Game");
        Time.timeScale = 1;
        isGameOver = false;
        OnGameStart?.Invoke();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        isGamePaused = true;
        OnGamePause?.Invoke();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        isGamePaused = false;
        OnGameResume?.Invoke();
    }

    public void GameOver() {
        isGameOver = true;
        Time.timeScale = 0;
        OnGameOver?.Invoke();
    }

    public void RestartLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}