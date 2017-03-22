﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour {

    public float startSpeed;
    public float increaseSpeed;
    public GameControllerScript gameControllerScript;

    // Use this for initialization
    void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float curentSpeed = startSpeed + increaseSpeed * gameControllerScript.gameTime;
        transform.Translate(new Vector3(-curentSpeed, 0, 0));
        if (transform.position.x < -17.75f)
        {
            Debug.Log("just");
            transform.Translate(new Vector3(17.75f * 2 * startSpeed / Mathf.Abs(startSpeed), 0, 0));
        }
    }
}
