using UnityEngine;
using System.Collections;

public class JumbFlamesScript : MonoBehaviour
{
    public float timeAlive = 3f;
    private bool x = true;
    // Use this for initialization
    void Update()
    {
        if (x)
        {
            Invoke("deActivate", timeAlive);
            x = false;
        }
    }
    // Update is called once per frame
    void  deActivate()
    {
        gameObject.SetActive(false);
        x = true;
    }
}
