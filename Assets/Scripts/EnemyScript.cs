using UnityEngine;
using System.Collections;

public class EnemyScript : PositionScaleLogic
{
    
    public float ScaleN = 1;
    
    public float timeAlive = 5;
    public bool changeScale = false;
    public float speedOfScaling;
    public float max = 24f;
    public float min = 1f;
    public float Gap = 1f;

    public float RedZonePos = 10f;
    public float greenCornerPos = .5f;
    public float SpeedOfFalling = 3;
    public Transform greenZoneR;
    public Transform greenZoneL;
    public Transform  RedZoneLeft;
    public Transform RedZoneRight;
    public Transform greenZone;
    public ParticleSystem explosionPrefab;
    
    private float GapBetRedACGZ = 0; //gap between red zone position and the corner of the green zone
    private float PositionN = 0;
    private bool rightleft;
    private float speed;
    void Start()
    {
        speed = SpeedOfFalling;
        SpeedOfFalling = 70;
        Invoke("changeSpeed", .5f);
        GapBetRedACGZ = RedZonePos - greenCornerPos + Gap;
        LoadScale(ScaleN);
        Destroy(gameObject, timeAlive);
        if (changeScale)
        {
            if (Random.value > .5)
            {
                rightleft = true;
            } else
            {
                rightleft = false;
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
            if (rightleft)
            {
                ScaleN += speedOfScaling * Time.deltaTime;
            } else
            {
                ScaleN -= speedOfScaling * Time.deltaTime;
            }
            LoadScale(ScaleN);
            if (ScaleN > max)
            {
                rightleft = false;
            } else if (ScaleN < min)
            {
                rightleft = true;
            }
        }
    }
    public void LoadScale(float scale)
    {
        PositionN = ScaleToPosition(scale, .38f + 1, 2.2145f);
        RedZoneLeft.position = new Vector3(-PositionN - GapBetRedACGZ, RedZoneRight.position.y, RedZoneRight.position.z);
        RedZoneRight.position = new Vector3(PositionN + GapBetRedACGZ, RedZoneRight.position.y, RedZoneRight.position.z);
        if (greenZoneR)
        {
            greenZoneL.localScale = greenZoneR.localScale = new Vector3(scale, greenZoneR.localScale.y, greenZoneR.localScale.z);
        }
    }
    public void DestroyWood()
    {
        ParticleSystem ex = Instantiate(explosionPrefab, greenZone.position, Quaternion.Euler(new Vector3(0, 0, 90))) as ParticleSystem;
        ex.transform.localScale = new Vector3(1f, .8f * ((ScaleN + .38f) * 2), 1f);
        AudioHelperScript.instance.makeExplosionSound();
        Destroy(greenZone.gameObject);
    }
}