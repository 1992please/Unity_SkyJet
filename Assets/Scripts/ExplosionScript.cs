using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{
    public float timeOut = 1f;
    // Use this for initialization
    void Awake()
    {
        Invoke("DestroyNow", timeOut);
    }
    // Update is called once per frame
    void DestroyNow()
    {
        Destroy(gameObject);
    }
}