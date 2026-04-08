using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameManagerJuegoVR GM;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            if ((GM.isCompleteGame()))
            {
                GM.GanarJuego();
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
