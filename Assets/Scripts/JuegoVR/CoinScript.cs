using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool isPlayerNear=false;
    private bool isTaken=false;    
    [SerializeField] GameManagerJuegoVR GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear=true;
            //Debug.Log("Entra Player");
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
    public void TakeCoin()
    {
        if (!isTaken&&isPlayerNear)
        {
            GM.SumarCoin();
            isTaken=true;
            gameObject.SetActive(false);
        }
    }
}
