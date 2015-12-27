using UnityEngine;
using System.Collections;

public class AudioTPHelper : MonoBehaviour
{
    public AudioSource music;
    // Use this for initialization
    void Awake()
    {
        music.volume = PlayerPrefs.GetFloat("SV");
    }
    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("SV");
    }
}
