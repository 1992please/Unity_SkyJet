using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMainHighestScoreScript : MonoBehaviour
{
    public Transform scoreGUI;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("BestPlayer"))
        {
            scoreGUI.GetComponent<Text>().text = "Highest Score is " + PlayerPrefs.GetInt("HighestScore") + " By " + PlayerPrefs.GetString("BestPlayer");
        }
    }
}
