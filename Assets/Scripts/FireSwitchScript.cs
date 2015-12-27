using UnityEngine;
using System.Collections;

public class FireSwitchScript : MonoBehaviour
{
    public Transform fire1;
    public Transform fire2;
    public float rateOfSwithcing = 1f;
    // Use this for initialization
    void Start()
    {
        Invoke("fire1Create", 0);
    }
	
    // Update is called once per frame
    private void fire1Create()
    {
        fire1.gameObject.SetActive(true);
        fire2.gameObject.SetActive(false);
        Invoke("fire2Create", rateOfSwithcing);
	    
    }
    private void fire2Create()
    {
        fire1.gameObject.SetActive(false);
        fire2.gameObject.SetActive(true);
        Invoke("fire1Create", rateOfSwithcing);
    }
}
