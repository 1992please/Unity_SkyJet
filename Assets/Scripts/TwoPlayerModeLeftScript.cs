using UnityEngine;
using System.Collections;

public class TwoPlayerModeLeftScript : TouchButtonLogic
{
    public Transform leftHand;
    public float SpeedOfScaling = .01f;
    public float maxSpeed = 10f;
    private float Adder = 0f;
    private bool Scale = false;
    public float max = 4.5f;
    public float min = 1f;
    
    private float shit = 0;
    private Animator animL;
    private HashIDs hash;
    void Awake()
    {
        animL = leftHand.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }
    
    override public  void OnTouchDown()
    {
        shit = 0;
        Adder = 0;
        Scale = true;
//        print("left down");
    }
    override public  void OnTouchUp()
    {
        shit = 0;
        Adder = 0;
        Scale = false;
//        print("left Up");
    }
    void Update()
    {
        CheckTouches();
    }
    void FixedUpdate()
    {
        
        if (Adder < maxSpeed)
        {
            Adder = Mathf.Pow((1 + SpeedOfScaling), shit++);
            
        } else
        {
            Adder = maxSpeed;
        }
        if (Scale)
        {
            Vector3 L = leftHand.position - new Vector3(Adder, 0, 0) * Time.deltaTime;
            if (-L.x >= max)
            {
                leftHand.position = new Vector3(-max, leftHand.position.y, leftHand.position.z);
                animL.SetFloat(hash.speedFloat, 0);
            } else
            {
                leftHand.position = L;
                animL.SetFloat(hash.speedFloat, Adder);
            }
            
        } else
        {
            Vector3 L = leftHand.position + new Vector3(Adder, 0, 0) * Time.deltaTime;
            if (-L.x <= min)
            {
                leftHand.position = new Vector3(-min, leftHand.position.y, leftHand.position.z);
                animL.SetFloat(hash.speedFloat, 0);
            } else
            {
                leftHand.position = L;
                animL.SetFloat(hash.speedFloat, -Adder);
            }
            
        }
    }
}
