using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] float jumpForce;
    private Vector2 moveInput;
    private Rigidbody rb;
    private bool shouldJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Debug.Log("Movimiento");
        // Leemos el valor (Vector2) que viene del teclado/mando
        moveInput = context.ReadValue<Vector2>();
        
        // Detectar cuando se suelta la tecla
        if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        shouldJump=true;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 targetVelocity = moveDirection * speed;
        //Dos formas de hacer. La mejor seria con velocidad linear para movimiento "natural"
        //rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        if (shouldJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            shouldJump=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
