using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewHighScoreScript : MonoBehaviour
{

    public Transform scoreGUI;
    public Transform nameGUI;
    public Transform mainMenuButtonGUI;
    public Transform tryAgainButtonGUI;
    
    private Text score;
    private InputField playerName = null;
    private Button mainMenuButton = null;
    private Button tryAgainButton = null;
    // Use this for initialization

    void Start()
    {
        score = scoreGUI.GetComponent<Text>();
        playerName = nameGUI.GetComponent<InputField>();
        mainMenuButton = mainMenuButtonGUI.GetComponent<Button>();
        tryAgainButton = tryAgainButtonGUI.GetComponent<Button>();

        score.text = "" + PlayerPrefs.GetInt("RightScore");
        //playerName.validation = InputField.Validation.Alphanumeric;
        mainMenuButton.onClick.AddListener(() => mainMenu());
        tryAgainButton.onClick.AddListener(() => singlePlayer());
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainMenu();
        }
    }
    void mainMenu()
    {
        PlayerPrefs.SetString("BestPlayer", playerName.text);
        PlayerPrefs.SetInt("HighestScore", PlayerPrefs.GetInt("RightScore"));
        Application.LoadLevel("MainMenuScene");
    }
    void singlePlayer()
    {
        PlayerPrefs.SetString("BestPlayer", playerName.text);
        PlayerPrefs.SetInt("HighestScore", PlayerPrefs.GetInt("RightScore"));
        Application.LoadLevel("SinglePlayerScene");
    }
}
