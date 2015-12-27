using UnityEngine;
using System.Collections;

public class AudioHelperScript : MonoBehaviour
{
    
    public static AudioHelperScript instance;
    public AudioSource music;
    public AudioSource Electricity;

    public AudioClip explosionSound;
    public AudioClip takeCharge;
    public AudioClip takeLevelUp;
    public AudioClip whileFly;
    public AudioClip whileJumb;
    public AudioClip falling;

    public float musicVolume = 1f;
    public float SFVolume = 1f;
    public float ElectricityVolume = .7f;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper");
        }
        instance = this;

        music.volume = PlayerPrefs.GetFloat("SV");
        Electricity.volume = PlayerPrefs.GetFloat("SFV") * ElectricityVolume;
    }
    public void makeExplosionSound()
    {
        AudioSource sound = createAudioHere(explosionSound);
        sound.volume = PlayerPrefs.GetFloat("SFV");
    }
    public void makeTakeChargeSound()
    {
        AudioSource sound = createAudioHere(takeCharge);
        sound.volume = PlayerPrefs.GetFloat("SFV") * .4f;
    }
    public void makeFlySound()
    {
        AudioSource sound = createAudioHere(whileFly);
        sound.volume = PlayerPrefs.GetFloat("SFV");
    }
    public void makeJumbSound()
    {
        AudioSource sound = createAudioHere(whileJumb);
        sound.volume = PlayerPrefs.GetFloat("SFV") * .3f;
    }
    public void makeTakeLevelUpSound()
    {
        AudioSource sound = createAudioHere(takeLevelUp);
        sound.volume = PlayerPrefs.GetFloat("SFV") * .3f;
    }
    public void makeFallingSound()
    {
        AudioSource sound = createAudioHere(falling);
        sound.volume = PlayerPrefs.GetFloat("SFV");
    }
    public void StartElectricity()
    {
        Electricity.Play();
    }
    public void StopElectricity()
    {
        Electricity.Stop();
    }
    private AudioSource createAudioHere(AudioClip orignalClip)
    {
        GameObject tempOb = new GameObject("TempAu");
        tempOb.transform.position = transform.position;
        AudioSource source = tempOb.AddComponent<AudioSource>();
        source.clip = orignalClip;
        source.Play();
        Destroy(tempOb, orignalClip.length);
        return source; 
    }
}
