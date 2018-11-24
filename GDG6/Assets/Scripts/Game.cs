using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    
    private void Awake()
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

    public void GameOver()
    {
        Instantiate(PrefabsManager.instance.GameOverCanvas);
    }
}