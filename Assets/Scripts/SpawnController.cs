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

    public float rocksH=3.6f;
    public float workSpaceH=6f;

    private float curentSpawnTime;
    private float curentRange;
    private float timeInterval=10f;

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
            if (minSpawnTime < curentSpawnTime)
                 curentSpawnTime -= incTime;
            if (minRange < curentRange)
                curentRange -= incRange;
            timeInterval = 0;
            SpawnRocks();
        }
	}

    void SpawnRocks()
    {
        float length = rocksH + curentRange / 2;
        float shift = Random.Range(-(workSpaceH - curentRange)/2, (workSpaceH - curentRange) / 2); 
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y -length-shift, transform.position.z);
        GameObject rock = Instantiate(rockPrefab, spawnPos, Quaternion.identity) as GameObject;
        spawnPos = new Vector3(transform.position.x, transform.position.y + length-shift, transform.position.z);
        GameObject rockDown = Instantiate(rockDownPrefab, spawnPos, Quaternion.identity) as GameObject;

    }
}
