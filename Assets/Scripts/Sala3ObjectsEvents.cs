using UnityEngine;
using System.Collections;

public class Sala3ObjectsEvents : MonoBehaviour
{
    // Renderer: componente que dibuja el mesh del objeto en pantalla
    private Renderer _renderer;

    // Color original guardado para poder restaurarlo después
    private Color _originalColor;
    private float gradosTotales = 360f;
    private float duracion = 3f;
    private Coroutine corrutinaRot;
    private bool isRotation = false;

    private void Awake()
    {
        // GetComponent: busca el componente en este mismo GameObject
        _renderer      = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    // Llama este método para poner el objeto en rojo (daño)
    public void SetCapsuleSelectedColor()
    {
        _renderer.material.color = Color.red;
    }

    // Llama este método para restaurar el color original
    public void RestoreColor()
    {
        _renderer.material.color = _originalColor;
    }
    public void CilindroRotacion()
    {
        if (corrutinaRot != null) StopCoroutine(corrutinaRot);        
        corrutinaRot = StartCoroutine(RotarObjeto());    
    }
    IEnumerator RotarObjeto()
    {
        float tiempoPasado = 0f;
        Quaternion rotacionInicial = transform.rotation;
        
        Quaternion rotacionFinal = rotacionInicial * Quaternion.Euler(0, gradosTotales, 0);

        while (tiempoPasado < duracion)
        {
            transform.rotation = Quaternion.Lerp(rotacionInicial, rotacionFinal, tiempoPasado / duracion);
            
            tiempoPasado += Time.deltaTime;
            yield return null; // Espera al siguiente frame
        }

        transform.rotation = rotacionFinal;
    }
}
