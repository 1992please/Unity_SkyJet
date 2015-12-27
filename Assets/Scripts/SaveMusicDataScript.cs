using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveMusicDataScript : MonoBehaviour
{
    public Transform SVSlider;
    public Transform SFVSlider;
    public Transform MainToggle;
    public Transform MusicToggle;
    public Transform SFToggle;
    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.GetFloat("SFV") != 0)
        {
            SVSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFV");
        }
        if (PlayerPrefs.GetFloat("SV") != 0)
        {
            SFVSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SV");
        }
    }
    public void onClick()
    {
        if (MainToggle.GetComponent<Toggle>().isOn)
        {
            if (MusicToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetFloat("SV", SVSlider.GetComponent<Slider>().value);
            } else
            {
                PlayerPrefs.SetFloat("SV", 0);
            }
            if (SFToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetFloat("SFV", SFVSlider.GetComponent<Slider>().value);
            } else
            {
                PlayerPrefs.SetFloat("SFV", 0);

            }
        } else
        {
            PlayerPrefs.SetFloat("SV", 0);
            PlayerPrefs.SetFloat("SFV", 0);
        }
    }
}
