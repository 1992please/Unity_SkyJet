using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISFVolumeScript : MonoBehaviour
{

    public Transform Pannel;

    void Awake()
    {
        if (PlayerPrefs.GetFloat("SFV") == 0)
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
