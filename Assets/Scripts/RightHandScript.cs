using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightHandScript : MonoBehaviour
{
    public bool anotherPlayer = false;
    public int score = 0;
    public int voltage = 0;
    public int terbo = 0;
    public int voltageCapacity = 20;
    public int terboCapacity = 10;
    public int electricityTimer = 5;
    private int dischargingCountDown = 0;
    public bool charged = false;
    public bool flying = false;
    public Transform scoreGUI;
    public Transform lightning;
    public Transform lightning1;
    public Transform voltageSliderGUI;
    public Transform terboSliderGUI;
    public Transform flamesRight;
    public Transform flamesLeft;    
    public Transform flamesRight1;
    public Transform flamesLeft1;
    public Transform bridgePrefab;

    private UISliderColorChanging voltageSlider = null;
    private UISliderColorChanging terboSlider = null;
    private Text scoreText = null;
    private Animation anim;
    private Animation animCam;
    //private HashIDs hash;
    // Use this for initialization
    void Start()
    {
        scoreText = scoreGUI.GetComponent<Text>();
        voltageSlider = voltageSliderGUI.GetComponent<UISliderColorChanging>();
        voltageSliderGUI.GetComponent<Slider>().maxValue = voltageCapacity;
        terboSlider = terboSliderGUI.GetComponent<UISliderColorChanging>();
        terboSliderGUI.GetComponent<Slider>().maxValue = terboCapacity;
        anim = GetComponentInParent<Animation>();
        animCam = Camera.main.GetComponentInParent<Animation>();
        //hash = GetComponent<HashIDs>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "lose":
                PlayerPrefs.SetInt("RightScore", score);
                if (anotherPlayer)
                {
                    PlayerPrefs.SetString("Winner", PlayerPrefs.GetString("BlackName"));
                    Application.LoadLevel("TwoPlayersLoseScene");
                } else
                {
                    Application.LoadLevel("LoseScene");
                }
                break;
            case "score":
                    //EnemyScript enemy = other.GetComponent<EnemyScript>();
                if (charged)
                {
                    if (anotherPlayer)
                    {
                        other.GetComponent<EnemyScriptT>().DestroyWood();
                    } else
                    {
                        other.GetComponent<EnemyScript>().DestroyWood();
                    }
                    score += Random.Range(2, 6);
                    scoreText.text = "Score: " + score;
                    if (--dischargingCountDown == 0)
                    {
                        AudioHelperScript.instance.StopElectricity();
                        voltageSlider.changeValue(voltage);
                        charged = false;
                        lightning.gameObject.SetActive(false);
                        lightning1.gameObject.SetActive(false);
                    }
                } else
                {
                    scoreText.text = "Score: " + ++score;
                }
                break;
            case "charge":
                addVoltage();
                Destroy(other.gameObject);
                //print("charge");
                break;
            case "terbo":
                Destroy(other.gameObject);
                Jumb();
                break;
            case "fly":
                AddTerbo();
                Destroy(other.gameObject);
                break;
            case "fall":
                falling();
                break;
        }
    }
    public void addVoltage()
    {
        AudioHelperScript.instance.makeTakeChargeSound();
        scoreText.text = "Score: " + ++score;
        if (++voltage == voltageCapacity)
        {
            voltageSlider.changeValue(voltage);
            charged = true;
            dischargingCountDown = electricityTimer;
            voltage = 0;

            lightning.gameObject.SetActive(true);
            lightning1.gameObject.SetActive(true);
            AudioHelperScript.instance.StartElectricity();			
        }

        if (!charged)
        {
            voltageSlider.changeValue(voltage);
        }
    }
    public void AddTerbo()
    {
        scoreText.text = "Score: " + ++score;
        AudioHelperScript.instance.makeTakeLevelUpSound();
        if (++terbo == terboCapacity)
        {
            terboSlider.changeValue(terbo);
            Instantiate(bridgePrefab);
            fly();
            terbo = 0;
        } else
        {
            terboSlider.changeValue(terbo);
        }
    }
    public void Jumb()
    {
        AudioHelperScript.instance.makeJumbSound();
        anim.Stop();
        animCam.Stop();
        anim.Play("Jumb");
        animCam.Play("JumbCamera");
        scoreText.text = "Score: " + ++score;
        flamesLeft.gameObject.SetActive(true);
        flamesRight.gameObject.SetActive(true);
    }
    public void fly()
    {
        anim.Stop();
        animCam.Stop();
        AudioHelperScript.instance.makeFlySound();
        flying = true;
        anim.Play("fly");
        animCam.Play("flyCamera");
        flamesLeft1.gameObject.SetActive(true);
        flamesRight1.gameObject.SetActive(true);
    }

    public void falling()
    {
        AudioHelperScript.instance.makeFallingSound();
        flying = false;
        anim.Play("fall");
        animCam.Play("fallCamera");
        terboSlider.changeValue(terbo);
    }
}