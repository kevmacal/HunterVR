using UnityEngine;

public class LightsOnOff : MonoBehaviour
{
    [SerializeField] GameObject LuzAsociada;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OffLight();
        }
    }
    void OnLight()
    {
        LuzAsociada.SetActive(true);
    }
    void OffLight()
    {
        LuzAsociada.SetActive(false);
    }
}
