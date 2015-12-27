using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class LoseScript : MonoBehaviour
{
    public Transform highScoreCanvas;
    public Transform normalScoreCanvas;
    // Use this for initialization
    void Awake()
    {
        if (!PlayerPrefs.HasKey("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", 0);
            PlayerPrefs.GetString("BestPlayer", "No One");
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("RightScore") > PlayerPrefs.GetInt("HighestScore"))
        {
            highScoreCanvas.gameObject.SetActive(true);
        } else
        {
            normalScoreCanvas.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame

}