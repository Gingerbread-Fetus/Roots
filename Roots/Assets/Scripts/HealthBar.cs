using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthSlider;
    [SerializeField] Health playerHealthObject;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        float healthPercentage = playerHealthObject.healthPoints / playerHealthObject.maxHealthPoints;
        healthSlider.value = healthPercentage;
    }
}
