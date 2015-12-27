using UnityEngine;
using System.Collections;

public class TwoPlayerModeRightScript : TouchButtonLogic
{
    public Transform rightHand;
    public float SpeedOfScaling = .01f;
    public float maxSpeed = 10f;
    private float Adder = 0f;
    private bool Scale = false;
    public float max = 4.5f;
    public float min = 1f;
    
    private float shit = 0;
    private Animator animR;
    private HashIDs hash;
    void Awake()
    {
        animR = rightHand.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }
	
    override public  void OnTouchDown()
    {
        shit = 0;
        Adder = 0;
        Scale = true;
//        print("right down");
    }
    override public  void OnTouchUp()
    {
        shit = 0;
        Adder = 0;
        Scale = false;
//        print("right Up");
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
            Vector3 R = rightHand.position + new Vector3(Adder, 0, 0) * Time.deltaTime;
            if (R.x >= max)
            {
                rightHand.position = new Vector3(max, rightHand.position.y, rightHand.position.z);
                animR.SetFloat(hash.speedFloat, 0);
            } else
            {
                rightHand.position = R;
                animR.SetFloat(hash.speedFloat, Adder);
            }
			
        } else
        {
            Vector3 R = rightHand.position - new Vector3(Adder, 0, 0) * Time.deltaTime;
            if (R.x <= min)
            {
                rightHand.position = new Vector3(min, rightHand.position.y, rightHand.position.z);
                animR.SetFloat(hash.speedFloat, 0);
            } else
            {
                rightHand.position = R;
                animR.SetFloat(hash.speedFloat, -Adder);
            }
			
        }
    }
}
