using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] float jumpForce;
    private Vector2 moveInput;
    private Camera mainCamera;
    private bool shouldJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        mainCamera = Camera.main;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        shouldJump=true;
    }
    void RotateTowardsMouse()
    {
        // 1. Capturamos la posición del mouse
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // 2. Creamos un rayo desde la cámara
        Ray ray = mainCamera.ScreenPointToRay(mousePos);

        // 3. Creamos un plano horizontal invisible a la altura del jugador
        // El primer parámetro es la dirección hacia arriba, el segundo es un punto en el plano
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            // 4. Calculamos el punto exacto donde el rayo cruza el plano del jugador
            Vector3 targetPoint = ray.GetPoint(rayDistance);

            // 5. Obtenemos la dirección y forzamos que no mire hacia arriba/abajo (Y=0)
            Vector3 lookDirection = targetPoint - transform.position;
            //lookDirection.x=0;
            //lookDirection.z=0;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                // 6. Aplicamos la rotación instantánea y limpia
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);        

        if (shouldJump)
        {
            move=new Vector3(moveInput.x, jumpForce, moveInput.y);
            shouldJump=false;
        }
        transform.Translate(move * speed * Time.deltaTime);
        RotateTowardsMouse();
    }
}
