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

    public float rocksH=3.6f;
    public float workSpaceH=6f;

    private float curentSpawnTime;
    private float curentRange;
    private float timeInterval=10f;
    private byte state=0;
    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        curentRange = startRange;
        curentSpawnTime = startSpawnTime;
    }
	
	// Update is called once per frame
	void Update () {
        timeInterval += Time.deltaTime;
        if (timeInterval>= curentSpawnTime)
        {
            switch (state)
                {
                case 0:
                    if (minSpawnTime < curentSpawnTime)
                        curentSpawnTime -= incTime;
                    if (minRange < curentRange)
                        curentRange -= incRange;
                    timeInterval = 0;
                    SpawnRocks();
                    state = 1;
                    break;
                case 1:
                    timeInterval = 0;
                    SpawnCoin();
                    state = 0;
                    break;
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
}
