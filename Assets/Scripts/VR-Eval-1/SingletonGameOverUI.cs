using UnityEngine;

public class SingletonGameOverUI : MonoBehaviour
{
    public static SingletonGameOverUI Instance { get; private set; }
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
