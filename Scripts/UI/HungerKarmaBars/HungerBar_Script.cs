using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar_Script : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHunger(float hunger)
    {
      slider.maxValue = hunger;
      slider.value = hunger;

      fill.color = gradient.Evaluate(1.0f);
    }

    public void SetHunger(float hunger)
    {
      slider.value = hunger;

      fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
