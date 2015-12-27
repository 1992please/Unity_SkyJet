using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int speedFloat;
    public  int jumbState;
    void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        jumbState = Animator.StringToHash("Base Layer.jumb");
    }
}
