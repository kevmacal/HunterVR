using UnityEngine;

public class SingletonPauseUI : MonoBehaviour
{
    public static SingletonPauseUI Instance { get; private set; }
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
}
