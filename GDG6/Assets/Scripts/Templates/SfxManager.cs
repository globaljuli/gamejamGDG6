using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    [Header("Player")] 
    public AudioClip Audio1;

    [Header("Enemies")] 
    public AudioClip Audio2;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}