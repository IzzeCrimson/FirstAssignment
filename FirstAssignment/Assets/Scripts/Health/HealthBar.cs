using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health _healthScript;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentHealthText;
    [SerializeField] private TextMeshProUGUI _maxHealthText;

    public void HealthBarSetUp(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
        _maxHealthText.text = maxHealth.ToString();
        _currentHealthText.text = maxHealth.ToString();
    }

    public void SetHealthValue(float health)
    {
        _slider.value = health;
        _currentHealthText.text = health.ToString();
    }

    private void Awake()
    {
        _healthScript = gameObject.GetComponent<Health>();
    }

    void Start()
    {
        HealthBarSetUp(_healthScript.maxHealth);

    }


    void Update()
    {
        
    }
}
