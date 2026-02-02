using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource sfxSource;

    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip step;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCoin()
    {
        sfxSource.PlayOneShot(coin);
    }

    public void PlayHurt()
    {
        sfxSource.PlayOneShot(hurt);
    }

    public void PlayStep()
    {
        sfxSource.PlayOneShot(step);
    }
}
