using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIOnMusicVolumeChanged : MonoBehaviour
{
    void Awake()
    {
        if (name == "SliderSF")
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFV");
        } else
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("SV");
        }
    }
    public void onChanged()
    {
        PlayerPrefs.SetFloat("SV", GetComponent<Slider>().value);
    }
    public void onChanged2()
    {
        PlayerPrefs.SetFloat("SFV", GetComponent<Slider>().value);
    }
}
