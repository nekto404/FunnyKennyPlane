using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameControllerScript gameControllerScript;
    public float startSpawnTime;
    public float startRange;
    public float incTime;
    public float incRange;
    public float minSpawnTime;
    public float minRange;

    public GameObject rockPrefab;
    public GameObject rockDownPrefab;

    public GameObject gold_coint;
    public GameObject silver_coint;
    public GameObject bronze_coint;

    public GameObject FlyEnemyPrefab;

    public GameObject SignalLights;

    public float rocksH=3.6f;
    public float workSpaceH=6f;

    private float curentSpawnTime;
    private float curentRange;
    private float timeInterval=10f;
    private int state=0;

    private int flyEnemySpawns=0;
    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        curentRange = startRange;
        curentSpawnTime = startSpawnTime;
    }
	
	// Update is called once per frame
	void Update () {
        timeInterval += Time.deltaTime;
	    if (!gameControllerScript.getEnd())
	    {
	        if (timeInterval >= curentSpawnTime)
	        {
	            state =  Random.Range(0, 3);
	            switch (state)
	            {
	                case 0:
	                    if (minSpawnTime < curentSpawnTime)
	                        curentSpawnTime -= incTime;
	                    if (minRange < curentRange)
	                        curentRange -= incRange;
	                    timeInterval = 0;
	                    SpawnRocks();
	                    break;
	                case 1:
	                    timeInterval = 0;
	                    SpawnCoin();
	                    break;
	                case 2:
	                    timeInterval = 0;
	                    SpawnEnemy(Random.Range(0, flyEnemySpawns / 5) + 1);
	                    flyEnemySpawns++;
	                    break;
	            }
	        }
	    }
	}

    void SpawnRocks()
    {
        float length = rocksH + curentRange / 2;
        float shift = Random.Range(-(workSpaceH - curentRange)/2, (workSpaceH - curentRange) / 2); 
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y -length-shift, transform.position.z);
        Instantiate(rockPrefab, spawnPos, Quaternion.identity);
        spawnPos = new Vector3(transform.position.x, transform.position.y + length-shift, transform.position.z);
        Instantiate(rockDownPrefab, spawnPos, Quaternion.identity);
        SignalLights.GetComponent<SingnalLights>().ShowWrning(transform.position.y  - curentRange /2 - shift, transform.position.y + curentRange / 2 - shift);
    }

    void SpawnCoin()
    {
        int chanse = Random.Range(0,100);
        float shift = Random.Range(-(workSpaceH) / 2, (workSpaceH) / 2);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - shift, transform.position.z);
        if (chanse > 95)
        {
           Instantiate(gold_coint, spawnPos, Quaternion.identity);
        }
        else if (chanse > 80)
        {
            Instantiate(silver_coint, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(bronze_coint, spawnPos, Quaternion.identity);
        }
    }

    void SpawnEnemy(int EnemiesCount)
    {
        for (int i = 0; i < EnemiesCount; i++)
        {
            float maxHeight = Random.Range(0, workSpaceH / 2);
            float minHeight = Random.Range(-workSpaceH / 2, 0);
            float shift = Random.Range(minHeight, maxHeight);
            Vector3 spawnPos = new Vector3(transform.position.x+3*i, transform.position.y - shift, transform.position.z);
            GameObject enemy = Instantiate(FlyEnemyPrefab, spawnPos, Quaternion.identity) as GameObject;
            enemy.GetComponent<FlyEnemy>().maxHeight = maxHeight;
            enemy.GetComponent<FlyEnemy>().minHeight = minHeight;
        }
    }
}
