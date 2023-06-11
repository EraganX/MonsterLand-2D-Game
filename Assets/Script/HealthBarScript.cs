using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image _healthBar;
    public bool _isEat;
    public bool isHealing;
    [SerializeField] private float _addHealth = 0.3f;
    [SerializeField] private float _deductHealth = 0.3f;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
        isHealing = true;
        _healthBar.fillAmount = 1;
    }

    private void Update()
    {
        if (_healthBar.fillAmount > 0 && isHealing)
        {
            if (_isEat)
            {
                _healthBar.fillAmount += _addHealth;
                _isEat = false;
            }
            _healthBar.fillAmount -= _deductHealth * Time.deltaTime;
        }
        else
        {
            isHealing = false;
            return;
        }
        
        
    }
}
