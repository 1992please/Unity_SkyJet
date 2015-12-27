using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwoPlayerLoseScript : MonoBehaviour
{
    public Transform TextObject;
    public Transform WhiteScore;
    public Transform BlackScore;
    public Transform Score;
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("WhitePlayerScore"))
        {
            PlayerPrefs.SetInt("WhitePlayerScore", 0);
            PlayerPrefs.SetInt("BlackPlayerScore", 0);
        } 
        if (PlayerPrefs.GetString("Winner") == PlayerPrefs.GetString("WhiteName"))
        {
            PlayerPrefs.SetInt("WhitePlayerScore", PlayerPrefs.GetInt("WhitePlayerScore") + 1);
        } else
        {
            PlayerPrefs.SetInt("BlackPlayerScore", PlayerPrefs.GetInt("BlackPlayerScore") + 1);
        }
        Score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("RightScore");
        TextObject.GetComponent<Text>().text = "Winner is " + PlayerPrefs.GetString("Winner");
        WhiteScore.GetComponent<Text>().text = PlayerPrefs.GetString("WhiteName") + ": " + PlayerPrefs.GetInt("WhitePlayerScore");
        BlackScore.GetComponent<Text>().text = PlayerPrefs.GetString("BlackName") + ": " + PlayerPrefs.GetInt("BlackPlayerScore");
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }
    public void Again()
    {
        Application.LoadLevel("TwoPlayersScene");
    }
    public void MainMenu()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
