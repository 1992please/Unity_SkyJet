using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public int barrierCounter = 0;
    public float minEnemyScale = 1f;
    public float maxEnemyScale = 24f;
    public float minChargePos = 1f;
    public float maxChargePos = 24f;
    public float creationRate = 2.5f;
    public float chargesChance = .3f;
    public float terboChance = .3f;
    public float flyChance = .2f;
    public float speedOfFalling = 6f;
    public float lifeTime = 8f;
    public bool stopCounter = false;
    public float yPositionStart = 30f;
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;
    public Transform enemyPrefab4;
    public Transform enemyPrefab5;
    public Transform ChargePrefab;
    public Transform terboPrefab;
    public Transform levelUp;
    private int maxBarrierCounter = 178;
    private EnemyScript enemy;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("MakeEnemies");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenuScene");
        }
    }
    // Update is called once per frame
    IEnumerator MakeEnemies()
    {
        while (true)
        {
            Transform Enemy = null;
            if (barrierCounter == maxBarrierCounter)
            {
                barrierCounter = 0;
            }
            if (!stopCounter)
            {
                ++barrierCounter;
            }
            switch (barrierCounter)
            {
                case 38:
                    EnvironmentScript.instance.changeMode();
                    break;
                case 73:
                    EnvironmentScript.instance.changeMode();
                    break;
                case 108:
                    EnvironmentScript.instance.changeMode();
                    break;
                case 143:
                    EnvironmentScript.instance.changeMode();
                    break;
                case 178:
                    EnvironmentScript.instance.changeMode();
                    break;
            }

            if (barrierCounter < 38)
            {
                Enemy = Instantiate(enemyPrefab1) as Transform;
                enemy = Enemy.GetComponent<EnemyScript>();
                enemy.Gap = Random.Range(4.5f, 5.5f);
            } else if (barrierCounter < 73)
            {
                Enemy = Instantiate(enemyPrefab2) as Transform;
                enemy = Enemy.GetComponent<EnemyScript>();
                enemy.Gap = Random.Range(4.5f, 5.5f);

            } else if (barrierCounter < 108)
            {
                Enemy = Instantiate(enemyPrefab3) as Transform;
                enemy = Enemy.GetComponent<EnemyScript>();
                enemy.changeScale = true;
                enemy.Gap = Random.Range(4.5f, 5.5f);
            } else if (barrierCounter < 143)
            {
                Enemy = Instantiate(enemyPrefab4) as Transform;
                enemy = Enemy.GetComponent<EnemyScript>();
                //enemy.changeScale = true;
                enemy.Gap = Random.Range(4.5f, 5.5f);
            } else if (barrierCounter < 180)
            {
                Enemy = Instantiate(enemyPrefab5) as Transform;
                enemy = Enemy.GetComponent<EnemyScript>();
                enemy.changeScale = true;
                enemy.Gap = Random.Range(4.5f, 5.5f);
            }
            Enemy.position = new Vector3(0, yPositionStart, -10);
            enemy.ScaleN = Random.Range(minEnemyScale, maxEnemyScale);
            //enemy.ScaleN = maxEnemyScale;
            enemy.SpeedOfFalling = speedOfFalling;
            enemy.timeAlive = lifeTime;
            yield return new WaitForSeconds(creationRate / 2);
            // making some Icons .....................................................
            /////////////////////////////////////////////////////////////////////////////
            if (barrierCounter > 3)
            {
                if (Random.value < chargesChance)
                {
                    Transform charge = Instantiate(ChargePrefab) as Transform;
                    charge.position = new Vector3(0, yPositionStart, -10);
                    charge.position += new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    ChargeScript x = charge.GetComponent<ChargeScript>();
                    x.SpeedOfFalling = speedOfFalling;
                    x.timeAlive = lifeTime;
                    //charge.position += new Vector3(maxChargePos, 0, 0);
                }
                if (Random.value < chargesChance)
                {
                    Transform charge = Instantiate(ChargePrefab) as Transform;
                    charge.position = new Vector3(0, yPositionStart, -10);
                    charge.position -= new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    ChargeScript x = charge.GetComponent<ChargeScript>();
                    x.SpeedOfFalling = speedOfFalling;
                    x.timeAlive = lifeTime;
                    // charge1.position -= new Vector3(minChargePos, 0, 0);
                }
                if (Random.value < flyChance)
                {
                    Transform fly = Instantiate(levelUp) as Transform;
                    fly.position = new Vector3(0, yPositionStart, -10);
                    ChargeScript x = fly.GetComponent<ChargeScript>();
                    x.timeAlive = lifeTime;
                    if (Random.value < .5)
                    {
                        fly.position -= new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    } else
                    {
                        fly.position += new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    }
                    x.SpeedOfFalling = speedOfFalling;
                } else if (Random.value < terboChance)
                {
                    Transform terbo = Instantiate(terboPrefab) as Transform;
                    terbo.position = new Vector3(0, yPositionStart, -10);
                    if (Random.value < .5)
                    {
                        terbo.position -= new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    } else
                    {
                        terbo.position += new Vector3(Random.Range(minChargePos, maxChargePos), 0, 0);
                    }
                    TerboScript x = terbo.GetComponent<TerboScript>();
                    x.SpeedOfFalling = speedOfFalling;
                    x.timeAlive = lifeTime;
                }
            }
            yield return new WaitForSeconds(creationRate / 2);
        }
    }
}