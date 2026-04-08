using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private bool isPlayerNear=false;
    private bool isTaken=false;
    private Rigidbody rb;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    [SerializeField] GameManagerJuegoVR GM;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Posicion inicial
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear=true;
            //Debug.Log("Entra Player");
        }
        if (other.CompareTag("OOB"))
        {
            ResetKey();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear=false;
            //Debug.Log("Sale Player");
        }
    }
    public void ResetKey()
    {
        //Dejar sin fuerzas
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
                
        //Mover al inicio
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }
    public void TakeKey()
    {
        if (!isTaken&&isPlayerNear)
        {
            GM.SumarLlave();
            isTaken=true;
            gameObject.SetActive(false);
        }
    }
}
