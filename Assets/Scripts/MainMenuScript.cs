using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{

    public Transform singlePlayerButtonGUI;
    public Transform twoPlayerButtonGUI;
    public Transform QuitButtonGUI;


    // Use this for initialization
    void Awake()
    {
        if (!PlayerPrefs.HasKey("SV"))
        {
            PlayerPrefs.SetFloat("SV", 1);
            PlayerPrefs.SetFloat("SFV", 1);
        }
    }
    void Start()
    {

    }
    public void freeRun()
    {
        Application.LoadLevel("SinglePlayerScene");
    }
    public void twoPlayer()
    {
        Application.LoadLevel("TwoPlayersScene");
    }
    public void Quit()
    {
        PlayerPrefs.DeleteKey("BlackName");
        PlayerPrefs.DeleteKey("WhiteName");
        PlayerPrefs.DeleteKey("WhitePlayerScore");
        PlayerPrefs.DeleteKey("BlackPlayerScore");
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
}
