using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerJuegoVR : MonoBehaviour
{
    [Header("GameTime")]
    [SerializeField] float tiempoLimite; // Tiempo en float 300f por ejemplo son 5 min
    [SerializeField] int llavesTotales;
    private float tiempoRestante;
    private bool juegoTerminado = false;
    private int llavesAdquiridas=0;
    private int score=0;
    private int health=100;

    [Header("Referencias XRUI")]
    [SerializeField] private Canvas canvasPrincipal; // Canvas principal
    [SerializeField] private TextMeshProUGUI textoCronometro;
    [SerializeField] private GameObject panelFinJuego; // Panel de Tiempo Terminado
    [SerializeField] private TextMeshProUGUI textoLlaves;
    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoHealth;
    [SerializeField] private GameObject panelWinGame; // Panel de juego ganado
    [SerializeField] Image imagenPanelHealth;


    void Start()
    {
        Time.timeScale = 1f;
        tiempoRestante = tiempoLimite;
        if (panelFinJuego != null) panelFinJuego.SetActive(false);
        ActualizarLlavesXRUI();
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
    public void ActualizarLlavesXRUI()
    {
        textoLlaves.text=$"Llaves: {llavesAdquiridas} / {llavesTotales}";
    }
    public void ActualizarScoreXRUI()
    {
        textoScore.text=$"Score: {score}";
    }
    public void ActualizarHealthXRUI()
    {
        textoHealth.text=$"{health}";
    }
    void ActualizarPanelHealthXRUI()
    {
        float porcentaje = (float)health / 100;

        // El FillAmount de la imagen va de 0 a 1
        imagenPanelHealth.fillAmount = porcentaje;
    }

    public void SumarLlave()
    {
        llavesAdquiridas++;
        ActualizarLlavesXRUI();
    }
    public void SumarCoin()
    {
        score++;
        ActualizarScoreXRUI();
    }
    public bool isCompleteGame()
    {
        if (llavesAdquiridas==llavesTotales)
        {
            return true;
        }
        return false;
    }
    public void GanarJuego()
    {
        juegoTerminado = true;
        //tiempoRestante = 0;
        Time.timeScale = 0f;
        
        // Mostramos el panel de reinicio
        if (panelFinJuego != null)
        {
            panelWinGame.SetActive(true);
            
            // Forzamos que el Canvas sea visible aunque estuviera oculto por el jugador
            canvasPrincipal.enabled = true; 
        }
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
    public void DoDamage(int damage)
    {
        health=health-damage;
        if (health<=0)
        {
            health=0;
            ActualizarHealthXRUI();
            ActualizarPanelHealthXRUI();
            
            TerminarJuego();
        }
        else
        {
            ActualizarHealthXRUI();
            ActualizarPanelHealthXRUI();
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
