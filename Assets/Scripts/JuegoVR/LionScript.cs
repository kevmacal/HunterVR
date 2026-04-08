using UnityEngine;

public class LionScript : MonoBehaviour
{
    [SerializeField] GameManagerJuegoVR GM;
    private bool isLionActive=true;
    public float speed = 2.0f;        // Velocidad
    public float distance = 3.0f;     // Distancia recorrida
    
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        //Posicion Inicial
        startPosition = transform.position;
    }

    void Update()
    {
        if (isLionActive)
        {
            float currentDistance = Mathf.Abs(transform.position.z - startPosition.z);

            if (currentDistance >= distance)
            {
                //Si completa la distancia voltea
                Flip();
            }

            // Movimiento constante hacia adelante (según hacia donde mire el león)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }

    void Flip()
    {
        movingForward = !movingForward;

        // Rotacion para que vea hacia el otro lado
        transform.Rotate(0, 180, 0);        
        
        float adjustment = movingForward ? 0.05f : -0.05f;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + adjustment);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&isLionActive)
        {            
            GM.DoDamage(10);                  
        }
        if (other.CompareTag("Rock"))
        {
            RockScript rScript = other.GetComponentInParent<RockScript>();
            Debug.Log($"L:{rScript.GetIsRockSelected()}");
            if (!rScript.GetIsRockSelected())
            {
                GM.SumarCoin();
                GM.SumarCoin(); 
                isLionActive=false;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
    }
}
