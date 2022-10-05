using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health healthScript;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI currentHealthText;
    [SerializeField] TextMeshProUGUI maxHealthText;

    public void HealthBarSetUp(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        maxHealthText.text = maxHealth.ToString();
        currentHealthText.text = maxHealth.ToString();
    }

    public void SetHealthValue(float health)
    {
        slider.value = health;
        currentHealthText.text = health.ToString();
    }

    private void Awake()
    {
        healthScript = gameObject.GetComponent<Health>();
    }

    void Start()
    {
        HealthBarSetUp(healthScript.maxHealth);

    }


    void Update()
    {
        
    }
}
