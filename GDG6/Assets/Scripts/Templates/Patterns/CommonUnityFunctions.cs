using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CommonUnityFunctions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("hit player");
        }
    }
    
    private IEnumerator DestroyInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    [SerializeField] private Text _uiText;
    private IEnumerator WriteLeterByLeter(string text, float interval)
    {
        float t = 0f;
        int index = 1;
        while (index < text.Length)
        {
            if (t > interval)
            {
                t -= interval;
                _uiText.text = text.Substring(0, index);
                index++;
            }
            t += Time.deltaTime;
            yield return null;
        }
    }
    
    private void MoveAtSpeed(Vector3 speed)
    {
        transform.position += speed * Time.deltaTime;
    }
    
    private void MoveX(float displacement)
    {
        Vector3 v3 = transform.position;
        v3.x += displacement;
        transform.position = v3;
    }
    
    private IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        float t = 0;
        Vector3 origin = transform.position;
        
        while (t < duration)
        {
            t += Time.deltaTime;
            Vector3.Lerp(origin, target, t/duration);
            yield return null;
        }
    }
    
    [SerializeField] private Sprite[] _spriteSheet;
    
    // Not Unity-only functions:
    
    public EventHandler GameOverEvent;
    
    private void HandleGameOver()
    {
        EventHandler handler = GameOverEvent;
        if (handler != null)
        {
            handler(this, null);
        }
    }
    
    public EventHandler GamePaused;
    private void HandleGamePaused(PausedEventArgs isPaused)
    {
        EventHandler handler = GamePaused;
        if (handler != null)
        {
            handler(this, isPaused);
        }
    }

    public class PausedEventArgs : EventArgs
    {
        public bool IsPaused;
    }
}