using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    public float timeAlive = 10f;
    public float speedOfFalling = 3f;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, timeAlive);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speedOfFalling * Time.deltaTime);
    }
}
