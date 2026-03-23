using UnityEngine;

public class CuadrosScript : MonoBehaviour
{
    [SerializeField] GameObject Cuadro;
    private bool activate;
    void Start()
    {
        activate=false;
        Cuadro.SetActive(false);
    }
    public void ActivarDesactivar()
    {
        Debug.Log("Presionado");
        if (activate)
        {
            Cuadro.SetActive(false);
            activate=false;
        }
        else
        {
            Cuadro.SetActive(true);
            activate=true;
        }
    }
}
