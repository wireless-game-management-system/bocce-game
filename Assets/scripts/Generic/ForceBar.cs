using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
    public Slider sliderInstance;
    public void OnValueChanged(float value)        
    {
        sliderInstance.minValue = 0.0f;
        sliderInstance.maxValue = 1.0f;
        sliderInstance.value = 0.5f;
    }

}
