using UnityEngine;

public class RockScript : MonoBehaviour
{
    private bool isSelected=false;
    private bool isOnFloor=true;
    public bool GetIsRockSelected()
    {
        Debug.Log($"S:{isSelected} F:{isOnFloor}");
        if (!isOnFloor&&!isSelected)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isOnFloor=true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isOnFloor=false;
        }
        
    }

    public void GetRock()
    {
        isSelected=true;
        isOnFloor=false;
    }
    public void ThrowRock()
    {
        isSelected=false;
    }
}
