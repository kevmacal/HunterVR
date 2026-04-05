using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerJuegoVR : MonoBehaviour
{
    [Header("GameTime")]
    [SerializeField] float tiempoLimite; // Tiempo en float 300f por ejemplo son 5 min
    private float tiempoRestante;
    private bool juegoTerminado = false;

    [Header("Referencias XRUI")]
    [SerializeField] private Canvas canvasPrincipal; // Canvas principal
    [SerializeField] private TextMeshProUGUI textoCronometro;
    [SerializeField] private GameObject panelFinJuego; // Panel de Tiempo Terminado


    void Start()
    {
        Time.timeScale = 1f;
        tiempoRestante = tiempoLimite;
        if (panelFinJuego != null) panelFinJuego.SetActive(false);
    }

    void Update()
    {
        if (juegoTerminado) return;

        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoXRUI(tiempoRestante);
        }
        else
        {
            TerminarJuego();
        }
    }

    void ActualizarTextoXRUI(float tiempo)
    {
        if (tiempo < 0) tiempo = 0;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Opcional: Poner el texto en rojo si queda poco tiempo
        if (tiempo < 10) textoCronometro.color = Color.red;
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        tiempoRestante = 0;
        Time.timeScale = 0f;
        
        // Mostramos el panel de reinicio
        if (panelFinJuego != null)
        {
            panelFinJuego.SetActive(true);
            
            // Forzamos que el Canvas sea visible aunque estuviera oculto por el jugador
            canvasPrincipal.enabled = true; 
        }
        
    }

    // Esta función la llamará tu botón de la UI
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TestButton()
    {
        Debug.Log("Test");
    }
}
