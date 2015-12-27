using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    public Transform scoreGUI;
    public Transform highestScoreGUI;
    public Transform mainMenuButtonGUI;
    public Transform tryAgainButtonGUI;

    private Text score = null;
    private Text highestScore = null;
    private Button mainMenuButton = null;
    private Button tryAgainButton = null;
    // Use this for initialization
    void Start()
    {
        score = scoreGUI.GetComponent<Text>();
        highestScore = highestScoreGUI.GetComponent<Text>();
        mainMenuButton = mainMenuButtonGUI.GetComponent<Button>();
        tryAgainButton = tryAgainButtonGUI.GetComponent<Button>();
       
        score.text = "Score: " + PlayerPrefs.GetInt("RightScore");
        highestScore.text = "Highest Score is " + PlayerPrefs.GetInt("HighestScore") + " By " + PlayerPrefs.GetString("BestPlayer");
        mainMenuButton.onClick.AddListener(() => mainMenu());
        tryAgainButton.onClick.AddListener(() => singlePlayer());
    }
    void mainMenu()
    {
        Application.LoadLevel("MainMenuScene");
    }
    void singlePlayer()
    {
        Application.LoadLevel("SinglePlayerScene");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainMenu();
        }
    }
}
