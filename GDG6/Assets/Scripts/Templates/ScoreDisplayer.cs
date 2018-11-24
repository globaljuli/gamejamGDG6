using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public static ScoreDisplayer Instance;
    
    private Text _uiText;
    private int _score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _uiText = GetComponent<Text>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddScore(int add)
    {
        _score += add;
        _uiText.text = "SCORE\n" + _score;
    }

    public int GetScore()
    {
        return _score;
    }
}