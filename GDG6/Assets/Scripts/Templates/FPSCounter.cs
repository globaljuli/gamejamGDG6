using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float _counter = 0;
    private TextMesh _text;

    private void Awake()
    {
        _text = GetComponent<TextMesh>();
    }
    
    private void Update()
    {
        _counter += Time.deltaTime;
        
        if (_counter > 0.5f)
        {
            _counter -= 0.5f;
            _text.text = ("" + 1f / Time.deltaTime + "  ").Substring(0, 2);
        }
    }
}