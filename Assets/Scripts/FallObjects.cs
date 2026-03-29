using UnityEngine;
using System.Collections.Generic;

public class FallObjects : MonoBehaviour
{
    [Header("Objetos de la sala")]
    [SerializeField] private GameObject[] objetosGeometricos;

    // Listas para recordar ubicacion, rotacion y rigidbody inicial
    private List<Vector3> posicionesIniciales = new List<Vector3>();
    private List<Quaternion> rotacionesIniciales = new List<Quaternion>();
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    void Start()
    {
        // Al empezar, guardamos los datos de cada objeto de la lista
        foreach (GameObject obj in objetosGeometricos)
        {
            posicionesIniciales.Add(obj.transform.position);
            rotacionesIniciales.Add(obj.transform.rotation);
            
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                 //Si hay rigidbody inicialmente debe estar quieto
                rigidbodies.Add(rb);
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivarFisicas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetearObjetos();
        }
    }
    void ActivarFisicas(bool activo)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !activo;
            rb.useGravity = activo;
        }
    }
    void ResetearObjetos()
    {
        for (int i = 0; i < objetosGeometricos.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
            rigidbodies[i].useGravity = false;
            rigidbodies[i].linearVelocity = Vector3.zero;
            rigidbodies[i].angularVelocity = Vector3.zero;

            objetosGeometricos[i].transform.position = posicionesIniciales[i];
            objetosGeometricos[i].transform.rotation = rotacionesIniciales[i];
        }
    }
}
