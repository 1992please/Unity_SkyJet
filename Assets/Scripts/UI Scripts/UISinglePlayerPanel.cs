using UnityEngine;
using System.Collections;

public class UISinglePlayerPanel : MonoBehaviour
{
//    public Transform singlePlayerPanel;
    public Transform mainPanel;
    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            mainPanel.gameObject.SetActive(true);
        }
    }
}
