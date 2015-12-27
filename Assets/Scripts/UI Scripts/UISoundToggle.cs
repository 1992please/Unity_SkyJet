using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISoundToggle : MonoBehaviour
{

    void Awake()
    {
        if (PlayerPrefs.GetFloat("SFV") == 0 && PlayerPrefs.GetFloat("SV") == 0)
        {
            GetComponent<Toggle>().isOn = true;
        } else
        {
            GetComponent<Toggle>().isOn = false;
        }

    }
    public void OnToggle()
    {
        if (!GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetFloat("SFV", 1);
            PlayerPrefs.SetFloat("SV", 1);
        } else
        {
            PlayerPrefs.SetFloat("SFV", 0);
            PlayerPrefs.SetFloat("SV", 0);
        }
    }
}
