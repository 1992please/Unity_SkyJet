using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMusicVolumeToggle : MonoBehaviour
{
    public Transform Pannel;

    void Awake()
    {
        if (PlayerPrefs.GetFloat("SV") == 0)
        {
            GetComponent<Toggle>().isOn = false;
        }
    }
    public void OnToggle()
    {
        if (!GetComponent<Toggle>().isOn)
        {
            Pannel.gameObject.SetActive(true);
        } else
        {
            Pannel.gameObject.SetActive(false);
        }
    }
}
