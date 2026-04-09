using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class CanvasPlayer : MonoBehaviour
{
    // Referencia a la acción del botón B del mando derecho
    [SerializeField] private InputActionReference toggleAction;
    //[SerializeField] UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightControl;
    //[SerializeField] UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor leftControl;
    
    private Canvas canvasComponent;

    void Awake()
    {
        canvasComponent = GetComponent<Canvas>();
    }

    void OnEnable()
    {
        // Suscribirse al evento de presionar el botón
        toggleAction.action.Enable();
        toggleAction.action.performed += OnButtonBPressed;
    }

    void OnDisable()
    {
        // Desactivar para evitar errores de memoria
        toggleAction.action.performed -= OnButtonBPressed;
        toggleAction.action.Disable();
    }

    private void OnButtonBPressed(InputAction.CallbackContext context)
    {
        canvasComponent.enabled = !canvasComponent.enabled;
        if (canvasComponent.enabled)
        {
            //rightControl.lineType=UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor.LineType.StraightLine;
            //rightControl.maxRaycastDistance = 20f;
            //leftControl.lineType=UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor.LineType.StraightLine;
            //leftControl.maxRaycastDistance = 20f;
        }
        else
        {
            //rightControl.lineType = UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor.LineType.ProjectileCurve;
            //leftControl.lineType = UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor.LineType.ProjectileCurve;
        }
        
        //Debug.Log("Canvas Presionado: " + canvasComponent.enabled);
    }
}
