using UnityEngine;
using System.Collections;

public class EnvironmentScript : MonoBehaviour
{
    // public bool changeMode = false;
    public static EnvironmentScript instance;
    public float smoothFraction = 2f;
    public Color[] backGroundColors;
    public Color[] directionalLightColors;
    public Color[] cloudColors;
    public Transform clouds;
    public Transform backGround;
    public Transform directionalLight;
    public Transform rain;
    public Transform snow;

    private SpriteRenderer[] childClouds;
    private SpriteRenderer backGroundRender;
    private int modeIndex = 0;
    private bool start = false;
    // Use this for initialization
    void Start()
    {
        instance = this;
        childClouds = clouds.GetComponentsInChildren<SpriteRenderer>();
        backGroundRender = backGround.GetComponent<SpriteRenderer>();
    }
	
    // Update is called once per frame
    //indexes here are +1;
    void Update()
    {
        if (start)
        {
            float speed = Time.deltaTime * smoothFraction;
            directionalLight.GetComponent<Light>().color = Color.Lerp(directionalLight.GetComponent<Light>().color, directionalLightColors [modeIndex], speed);
            backGroundRender.color = Color.Lerp(backGroundRender.color, backGroundColors [modeIndex], speed);
            foreach (SpriteRenderer x in childClouds)
            {
                x.color = Color.Lerp(x.color, cloudColors [modeIndex], speed);
            }
        }
    }
    public void changeMode()
    {
        modeIndex++;
        if (modeIndex == 5)
        {
            modeIndex = 0;
        } 
        start = true;
        switch (modeIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                rain.gameObject.SetActive(true);
                break;
            case 3:
                rain.gameObject.SetActive(false);
                snow.gameObject.SetActive(true);
                break;
            case 4:
                snow.gameObject.SetActive(false);
                break;
            case 5:
                break;
        }
    }
}