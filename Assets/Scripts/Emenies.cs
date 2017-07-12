using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emenies : MonoBehaviour {

    public int EnemiesCount;

    public float workSpaceH = 6f;

    public GameObject FlyEnemyPrefab;

    void Start()
    {
        for (int i = 0; i < EnemiesCount; i++)
        {
            float maxHeight = Random.Range(0, workSpaceH / 2);
            float minHeight = Random.Range(-workSpaceH / 2, 0);
            float shift = Random.Range(minHeight, maxHeight);
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - shift, transform.position.z);
            GameObject Enemy = Instantiate(FlyEnemyPrefab, spawnPos, Quaternion.identity) as GameObject;
            Enemy.GetComponent<FlyEnemy>().maxHeight = maxHeight;
            Enemy.GetComponent<FlyEnemy>().minHeight = minHeight;
        }
    }

    void SpawnEnemy()
    {

    }
}
