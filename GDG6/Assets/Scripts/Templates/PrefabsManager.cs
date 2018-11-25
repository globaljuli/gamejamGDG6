using UnityEngine;


public class PrefabsManager : MonoBehaviour
{
    [Header("Enemies")]
    public GameObject Cupcake;
    public GameObject MasksBoss;
    
    [Header("Objects")] 
    public GameObject GameOverCanvas;
    public GameObject FadeOutCanvas;
    
    public static PrefabsManager instance;

    void Awake()
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