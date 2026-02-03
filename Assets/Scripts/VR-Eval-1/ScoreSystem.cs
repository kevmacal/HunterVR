using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour {
    [Header("Score")]
    [SerializeField] private int currentScore = 0;

    [Header("Events")]
    public UnityEvent<int> OnScoreChanged; // Pasa score actual

    public static ScoreSystem Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Evita duplicados al reiniciar
        }
    }

    public void AddScore(int points) {
        currentScore += points;
        OnScoreChanged?.Invoke(currentScore);
    }

    public void ResetScore() {
        currentScore = 0;
        OnScoreChanged?.Invoke(currentScore);
    }

    public int GetScore() {
        return currentScore;
    }
}
