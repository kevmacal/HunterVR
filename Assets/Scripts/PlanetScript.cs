//using System.Diagnostics;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private bool isActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Posicion inicial
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
        isActive=false;
        
        //Inicialmente es kinematic y no usa gravedad
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    public void ActivarFisicas()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    public void DesactivarFisicas()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    public void Activate()
    {
        isActive=true;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5f)
        {
            ResetearPlaneta();
        }
        if (isActive)
        {
            ActivarFisicas();
            isActive=false;
        }
    }

    public void ResetearPlaneta()
    {
        //Dejar sin fuerzas
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        DesactivarFisicas();
        isActive=false;
        
        //Mover al inicio
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }
    public void Pruebas()
    {
        Debug.Log("Activado");
    }
}
