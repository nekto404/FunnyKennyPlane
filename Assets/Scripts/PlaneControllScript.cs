﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllScript : MonoBehaviour {

    public int angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float speed = angle * Time.deltaTime/20;
        transform.Translate(new Vector3(0, speed, 0));
	}

    public void Up()
    {
        if (angle < 60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, 20));
            angle += 20;
        }
        Debug.Log(angle);
    }

    public void Down()
    {
        if (angle > -60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, -20));
            angle -= 20;
        }
        Debug.Log(angle);
        
    }
}
