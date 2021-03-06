﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointController : MonoBehaviour {

    public float startSpeed;
    public float increaseSpeed;
    public GameControllerScript gameControllerScript;
    public int value;
    // Use this for initialization
    void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerScript.getEnd() || gameControllerScript.getPause()) return;
        float curentSpeed = startSpeed + increaseSpeed * gameControllerScript.gameTime;
        transform.Translate(new Vector3(-curentSpeed, 0, 0));
        if (transform.position.x < -15f)
        {
            desroyCoint();
        }
    }

    public void desroyCoint()
    {
        Destroy(gameObject);
    }
}
