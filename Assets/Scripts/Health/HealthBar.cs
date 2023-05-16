using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = playerHealth.currentHealth;
        slider.value = playerHealth.currentHealth;
    }
    private void Update()
    {
        slider.value = playerHealth.currentHealth;
    }
}
