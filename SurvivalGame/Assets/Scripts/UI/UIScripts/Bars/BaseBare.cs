using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBare : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Image bar;

    public bool Test = true;

    [Header("Variables: ")]
    public int value = 50;
    public int minValue = 0;
    public int maxValue = 100;

    [Header("Colors:")]
    public Color hightValueColor;
    public Color lowValueColor;

    void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Test)
        {
            UpdateValue(value);
            Test = false;
        }
    }

    public void UpdateValue(int newValue)
    {
        value = newValue;
        if (value < minValue)
        {
            value = minValue;
        }
        else if (value > maxValue)
        {
            value = maxValue;
        }

        slider.value = value;
        ChangeColor();
    }

    void ChangeColor()
    {
        if (bar == null)
            return;
        float perc = (float)(value - minValue)/(float)(maxValue - minValue);
        Debug.Log(perc);
        Color colorToChange = Color.Lerp(lowValueColor, hightValueColor, perc);
        bar.color = colorToChange;
    }
}
