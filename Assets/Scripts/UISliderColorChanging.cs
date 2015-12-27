using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISliderColorChanging : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public Transform fillGUI;
    private Image fill;
    private Slider slider;
    // Use this for initialization
    void Awake()
    {
        fill = fillGUI.GetComponent<Image>();
        slider = GetComponent<Slider>();
    }
	
    // Update is called once per frame
    public void changeValue(float x)
    {
        slider.value = x;
        fill.color = startColor + (endColor - startColor) * (slider.value) / (slider.maxValue - slider.minValue);
    }
}
