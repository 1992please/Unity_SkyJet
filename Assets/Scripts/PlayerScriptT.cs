using UnityEngine;
using System.Collections;

public class PlayerScriptT: MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public float SpeedOfScaling = .01f;
    public float maxSpeed = 10f;
    private float Adder = 0f;
    private bool Scale = false;
    public float max = 4.5f;
    public float min = 1f;
    
    private float shit = 0;
    private Animator animL;
    private Animator animR;
    private HashIDs hash;

    void Awake()
    {
        animL = leftHand.GetComponent<Animator>();
        animR = rightHand.GetComponent<Animator>();
        hash = GetComponent<HashIDs>();
    }

    public  void OnTouchDown()
    {
        shit = 0;
        Adder = 0;
        Scale = true;
    }
    public  void OnTouchUp()
    {
        shit = 0;
        Adder = 0;
        Scale = false;
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
                leftHand.position = new Vector3(-max, leftHand.position.y, leftHand.position.z);
                animL.SetFloat(hash.speedFloat, 0);
                animR.SetFloat(hash.speedFloat, 0);
            } else
            {
                rightHand.position = R;
                leftHand.position -= new Vector3(Adder, 0, 0) * Time.deltaTime;
                animL.SetFloat(hash.speedFloat, Adder);
                animR.SetFloat(hash.speedFloat, Adder);
            }
            
        } else
        {
            Vector3 R = rightHand.position - new Vector3(Adder, 0, 0) * Time.deltaTime;
            if (R.x <= min)
            {
                rightHand.position = new Vector3(min, rightHand.position.y, rightHand.position.z);
                leftHand.position = new Vector3(-min, leftHand.position.y, leftHand.position.z);
                animL.SetFloat(hash.speedFloat, 0);
                animR.SetFloat(hash.speedFloat, 0);
            } else
            {
                rightHand.position = R;
                leftHand.position += new Vector3(Adder, 0, 0) * Time.deltaTime;
                animL.SetFloat(hash.speedFloat, -Adder);
                animR.SetFloat(hash.speedFloat, -Adder);
            }
            
        }
        
    }
}