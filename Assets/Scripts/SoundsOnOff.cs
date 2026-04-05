using UnityEngine;

public class SoundsOnOff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioController SonidoAsociado;
    private bool isPlaying=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPlaying)
            {
                OffSound();
                isPlaying=false;
            }
            else
            {
                OnSound();
                isPlaying=true;
            }
            //OnSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //OffSound();
        }
    }

    public void OnSound()
    {
        SonidoAsociado.ReproducirMusica();
    }
    public void OffSound()
    {
        SonidoAsociado.PausarMusica();
    }

}
