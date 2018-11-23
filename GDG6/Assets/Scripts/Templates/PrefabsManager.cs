using UnityEngine;


public class PrefabsManager : MonoBehaviour
{
    [Header("Enemies")]
    public GameObject Enemy1;
    
    [Header("Items")] 
    public GameObject Item1;
    
    public static PrefabsManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}