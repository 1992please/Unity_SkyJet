using UnityEngine;
using System.Collections;

public class TwoPlayerSaveLoadScript : MonoBehaviour
{
    public Transform StartUp;
    public Transform Load;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("WhiteName"))
        {
            Load.gameObject.SetActive(true);
        } else
        {
            StartUp.gameObject.SetActive(true);
        }
    }
}
