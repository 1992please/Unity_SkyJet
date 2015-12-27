using UnityEngine;
using System.Collections;

public class EnemyScriptT : PositionScaleLogic
{

    public float ScaleNR = 1;
    public float ScaleNL = 1;
    
    public float timeAlive = 5;
    public bool changeScale = false;
    public float speedOfScaling;
    public float max = 24f;
    public float min = 1f;
    public float GapL = 1f;
    public float GapR = 1f;
    public float RedZonePos = 10f;
    public float greenCornerPos = .5f;
    public float SpeedOfFalling = 3;

    public Transform greenZoneR;
    public Transform greenZoneL;
    public Transform  RedZoneLeft;
    public Transform RedZoneRight;
    public Transform greenZone;
    public ParticleSystem explosionPrefab;

    private float GapBetRedACGZL = 0; //gap between red zone position and the corner of the green zone
    private float GapBetRedACGZR = 0; //gap between red zone position and the corner of the green zone
    private float PositionRightN = 0;
    private float PositionLeftN = 0;
    private bool rightleftL;
    private bool rightleftR;
    private float speed;
    void Start()
    {
        speed = SpeedOfFalling;
        SpeedOfFalling = 70;
        Invoke("changeSpeed", .5f);
        GapBetRedACGZL = RedZonePos - greenCornerPos + GapL;
        GapBetRedACGZR = RedZonePos - greenCornerPos + GapR;
        LoadScale(ScaleNR, ScaleNL);
        Destroy(gameObject, timeAlive);
        if (changeScale)
        {
            if (Random.value > .5)
            {
                rightleftL = true;
            } else
            {
                rightleftL = false;
            }
            if (Random.value > .5)
            {
                rightleftR = true;
            } else
            {
                rightleftR = false;
            }
        }
    }
    private void changeSpeed()
    {
        SpeedOfFalling = speed;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * SpeedOfFalling * Time.deltaTime);
        if (changeScale)
        {
            if (rightleftR)
            {
                ScaleNR += speedOfScaling * Time.deltaTime;
            } else
            {
                ScaleNR -= speedOfScaling * Time.deltaTime;
            }
            if (rightleftL)
            {
                ScaleNL += speedOfScaling * Time.deltaTime;
            } else
            {
                ScaleNL -= speedOfScaling * Time.deltaTime;
            }
            LoadScale(ScaleNR, ScaleNL);
            if (ScaleNR > max)
            {
                rightleftR = false;
            } else if (ScaleNR < min)
            {
                rightleftR = true;
            }
            if (ScaleNL > max)
            {
                rightleftL = false;
            } else if (ScaleNL < min)
            {
                rightleftL = true;
            }
        }
    }
    public void LoadScale(float scaleR, float scaleL)
    {
        PositionRightN = ScaleToPosition(scaleR, .38f + 1, 2.2145f);
        PositionLeftN = ScaleToPosition(scaleL, .38f + 1, 2.2145f);
        RedZoneLeft.position = new Vector3(-PositionLeftN - GapBetRedACGZL, RedZoneRight.position.y, RedZoneRight.position.z);
        RedZoneRight.position = new Vector3(PositionRightN + GapBetRedACGZR, RedZoneRight.position.y, RedZoneRight.position.z);
        if (greenZoneR)
        {
            greenZoneR.localScale = new Vector3(scaleR, greenZoneR.localScale.y, greenZoneR.localScale.z);
            greenZoneL.localScale = new Vector3(scaleL, greenZoneL.localScale.y, greenZoneL.localScale.z);
        }
        
    }
    public void DestroyWood()
    {
        ParticleSystem ex = Instantiate(explosionPrefab, greenZone.position, Quaternion.Euler(new Vector3(0, 0, 90))) as ParticleSystem;
        ex.transform.localScale = new Vector3(1f, .8f * ((ScaleNL + .38f) * 2), 1f);
        AudioHelperScript.instance.makeExplosionSound();
        Destroy(greenZone.gameObject);
        
    }
    public void Gap(float x)
    {
        GapL = GapR = x;
    }
}
