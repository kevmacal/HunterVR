using UnityEngine;

public class HelpBlockScript : MonoBehaviour
{
    [SerializeField] GameManagerJuegoVR GM;
    [SerializeField] Canvas ownCanvas;
    private bool isShow=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        ownCanvas.enabled=isShow;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isShow=true;
            ownCanvas.enabled=isShow;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isShow=false;
            ownCanvas.enabled=isShow;
        }
    }
}
