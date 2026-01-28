using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] float distanceX;
    [SerializeField] float distanceY;
    [SerializeField] float distanceZ;
    private Rigidbody rb;
    private float journeyLength;
    private Vector3 pointA;
    private Vector3 pointB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        pointA=new Vector3(transform.position.x,transform.position.y,transform.position.z);
        pointB=new Vector3(transform.position.x+distanceX,transform.position.y+distanceY,transform.position.z+distanceZ);
        journeyLength = Vector3.Distance(pointA, pointB);
    }

    void FixedUpdate()
    {
        // Calculamos el movimiento oscilante (de 0 a 1 y de vuelta)
        float time = Mathf.PingPong(Time.time * speed, 1);
        
        // Calculamos la posición exacta en este frame
        Vector3 targetPosition = Vector3.Lerp(pointA, pointB, time);
        
        // Movemos el Rigidbody físicamente
        rb.MovePosition(targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
