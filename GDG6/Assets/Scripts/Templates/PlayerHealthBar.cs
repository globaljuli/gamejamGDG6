using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Sprite[] flowerSprites;
    [SerializeField] private Image healthImage;
    private int currentHealth;
    
    public static PlayerHealthBar instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentHealth = 7;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void RemovePetalo()
    {
        currentHealth--;
        if (currentHealth < 0) currentHealth = 0;
        healthImage.sprite = flowerSprites[currentHealth];
    }

}