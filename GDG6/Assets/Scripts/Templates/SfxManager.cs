using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    AudioSource source;
    
    [Header("Player")] 
    public AudioClip shoot;
    public AudioClip playerHit;

    [Header("Enemies")] 
    public AudioClip enemyHit;
    public AudioClip evilLaugh;

    [Header("Background")]
    public AudioClip backgroundMusic;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            source = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}