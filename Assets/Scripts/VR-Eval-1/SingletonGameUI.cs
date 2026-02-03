using UnityEngine;

public class SingletonGameUI : MonoBehaviour
{
    public static SingletonGameUI Instance { get; private set; }
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
