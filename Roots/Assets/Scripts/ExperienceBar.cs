using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [HideInInspector]
    public Slider sliderCmp;
    [SerializeField]
    PlayerExperience playerExperience;

    private void Awake()
    {
        sliderCmp = GetComponent<Slider>();
    }

    private void Update()
    {
        float progress = (float)playerExperience.currentExp / (float)playerExperience.expToNextLevel;
        sliderCmp.value = progress;
    }
}
