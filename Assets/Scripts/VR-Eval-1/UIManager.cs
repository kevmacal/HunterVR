using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    [Header("UI Panels")]
    public GameObject initialUI;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    [SerializeField] HealthSystem HealthManager;
    [SerializeField] ScoreSystem ScoreManager;

    [Header("Game UI Elements")]
    public TextMeshProUGUI scoreText;
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    [Header("GameOver UI Elements")]
    public TextMeshProUGUI finalScoreText;

    void Start() {
        ShowInitialUI();
    }

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ShowInitialUI() {
        initialUI.SetActive(true);
        gameUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void ShowGameUI() {
        initialUI.SetActive(false);
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void UpdateScore(int score) {
        score=ScoreManager.GetScore();
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHealth(float healthPercent) {
        Image fillImage;
        healthPercent=HealthManager.GetHealthPercent();
        healthBar.value = healthPercent;
        healthText.text = $"Health: {(healthPercent * 100):F0}%";
        if (healthBar != null)
        {
            GameObject fillObject = healthBar.transform.Find("Fill Area/Fill").gameObject;
            fillImage = fillObject.GetComponent<Image>();
        
        //Debug.Log(healthBar.value);
        

        // Color según salud
            if (healthPercent > 0.5f) {
                fillImage.color=Color.green;
                //healthBar.color = Color.green;
            } else if (healthPercent > 0.25f) {
                fillImage.color=Color.yellow;
                //healthBar.color = Color.yellow;
            } else {
                fillImage.color=Color.red;
                //healthBar.color = Color.red;
            }
        }
    }

    public void ShowPauseUI() {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePauseUI() {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowGameOverUI() {
        gameOverUI.SetActive(true);
        finalScoreText.text= scoreText.text;
    }
}
