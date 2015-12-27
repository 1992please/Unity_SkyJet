using UnityEngine;
using System.Collections;

public class ChargeScript : MonoBehaviour
{
    public float timeAlive = 10f;
    public float SpeedOfFalling = 3f;
    private float speed;
    // Use this for initialization
    void Start()
    {
        speed = SpeedOfFalling;
        SpeedOfFalling = 70;
        Invoke("changeSpeed", .5f);
        Destroy(gameObject, timeAlive);
    }
    private void changeSpeed()
    {
        SpeedOfFalling = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * SpeedOfFalling * Time.deltaTime);
    }
}