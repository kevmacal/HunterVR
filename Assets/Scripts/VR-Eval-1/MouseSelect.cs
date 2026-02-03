using UnityEngine;
using UnityEngine.InputSystem;

public class MouseSelect : MonoBehaviour
{
    //Observer Pattern con la camara principal   
    public void ClickAction(InputAction.CallbackContext context)
    {
        //Debug.Log("Action");
        // Solo actuamos cuando el botón se presiona (no cuando se suelta)
        if (context.started)
        {
            Ray rayo = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(rayo, out RaycastHit hit))
            {
                IInteractable objeto = hit.collider.GetComponent<IInteractable>();
                objeto?.MouseClickSelect();
            }
        }
    }
}
