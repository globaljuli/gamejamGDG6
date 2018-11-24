using UnityEngine;

public class MonoSingleton : MonoBehaviour
{
    public static MonoSingleton Instance;
    
    private void Awake()
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