using System.Collections;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _whiteBar;
    [SerializeField] private Transform _redBar;
    
    private float _maxHP;
    private float _currentHP;
    private Coroutine _activeCoroutine;

    public void Init(float maxHealth)
    {
        _maxHP = maxHealth;
        _currentHP = maxHealth;
    }

    public void DealDamage(float damage)
    {
        UpdateHealth(_currentHP-damage);
    }
    
    public void UpdateHealth(float currentHealth)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = StartCoroutine(AdjustRedBar(_currentHP, currentHealth));
        _currentHP = currentHealth;
        _whiteBar.localScale = new Vector2(_currentHP / _maxHP, 1f);
    }

    private IEnumerator AdjustRedBar(float startingHealth, float currentHealth)
    {
        Vector2 startScale = new Vector2(startingHealth / _maxHP, 1f);
        Vector2 finalScale = new Vector2(currentHealth / _maxHP, 1f);
        yield return new WaitForSeconds(0.5f);
        
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime;
            _redBar.localScale = Vector2.Lerp(startScale, finalScale, t);
            yield return null;
        }

        _redBar.localScale = finalScale;
    }
}