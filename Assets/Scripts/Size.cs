using UnityEngine;
using System.Collections;

public class Size : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        print("size of " + gameObject.name + ": " + GetComponent<Collider>().bounds.size);
    }
    // Update is called once per frame
    void Update()
    {

    }
}