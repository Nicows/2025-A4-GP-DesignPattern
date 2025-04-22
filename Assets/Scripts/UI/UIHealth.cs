using System;
using Tanks.Complete;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private TankHealth _tankHealth;
    
    [SerializeField] private Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    [SerializeField] private Image m_FillImage;                           // The image component of the slider.
    [SerializeField] private Color m_FullHealthColor = Color.green;    // The color the health bar will be when on full health.
    [SerializeField] private Color m_ZeroHealthColor = Color.red;      // The color the health bar will be when on no health.

    private void Awake()
    {
        // Set the slider max value to the max health the tank can have
        m_Slider.maxValue = _tankHealth.StartingHealth;
    }

    private void OnEnable()
    {
        _tankHealth.OnHealthChanged += SetHealthUI;
    }

    private void OnDisable()
    {
        _tankHealth.OnHealthChanged -= SetHealthUI;
    }

    private void SetHealthUI ()
    {
        // Set the slider's value appropriately.
        m_Slider.value = _tankHealth.StartingHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, _tankHealth.Health / _tankHealth.StartingHealth);
    }
}
