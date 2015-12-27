using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingPlayerNamesScript : MonoBehaviour
{
    public Transform rightPlayerName;
    public Transform LeftPlayerName;
    public void setPlayerNames()
    {
        PlayerPrefs.SetString("WhiteName", rightPlayerName.GetComponent<Text>().text);
        PlayerPrefs.SetString("BlackName", LeftPlayerName.GetComponent<Text>().text);
        PlayerPrefs.DeleteKey("WhitePlayerScore");
        PlayerPrefs.DeleteKey("BlackPlayerScore");
    }
}
