using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour {
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [Header("Events")]
    public UnityEvent<float> OnHealthChanged; // Pasa % de salud
    public UnityEvent OnDeath;
    public UnityEvent OnHeal;
    public UnityEvent OnDamage;

    public static HealthSystem Instance { get; private set; }
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
    void Start() {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(GetHealthPercent());
    }
    public void resetHealth()
    {
        currentHealth=maxHealth;
        OnHealthChanged?.Invoke(GetHealthPercent());
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // No negativo

        OnDamage?.Invoke();
        OnHealthChanged?.Invoke(GetHealthPercent());

        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Heal(float amount) {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // No exceder max

        OnHeal?.Invoke();
        OnHealthChanged?.Invoke(GetHealthPercent());
    }

    public float GetHealthPercent() {
        return currentHealth / maxHealth;
    }

    void Die() {
        OnDeath?.Invoke();
        GameManager.Instance.GameOver();
    }
}
