using System.Runtime.Serialization;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] GameManagerJuegoVR GM;
    [SerializeField] GameObject KeyInserted;
    [SerializeField] GameObject Door;

    void Start()
    {
        KeyInserted.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            if ((GM.isCompleteGame()))
            {
                KeyInserted.SetActive(true);                
            }            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyInserted.SetActive(false);
        }
    }

    public void openDoor()
    {
        if (GM.isCompleteGame())
        {
            if (Door!=null)
            {
                Destroy(Door);
            }
        }
    }

    public void testButton()
    {
        Debug.Log("Test");
    }
    public void TestButtonHover()
    {
        Debug.Log("TestHover");
    }
    public void TestButtonSelect()
    {
        Debug.Log("TestSelect");
    }
    public void TestButtonFocus()
    {
        Debug.Log("TestFocus");
    }
}
