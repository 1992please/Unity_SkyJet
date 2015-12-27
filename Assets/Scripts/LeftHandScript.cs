using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeftHandScript : MonoBehaviour
{
    public bool anotherPlayer = false;
    public Transform rightHand;

    private RightHandScript otherHand;
    // Use this for initialization
    void Start()
    {
        otherHand = rightHand.GetComponent<RightHandScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (anotherPlayer && other.tag == "lose")
        {
            PlayerPrefs.SetString("Winner", PlayerPrefs.GetString("WhiteName"));
            print(PlayerPrefs.GetString("Winner"));
            Application.LoadLevel("TwoPlayersLoseScene");

        }
        if (other.tag == "charge")
        {
            otherHand.addVoltage();
            Destroy(other.gameObject);
        } else if (other.tag == "terbo")
        {
            Destroy(other.gameObject);
            otherHand.Jumb();
        } else if (other.tag == "fly")
        {
            Destroy(other.gameObject);
            otherHand.AddTerbo();
        }
    }
}