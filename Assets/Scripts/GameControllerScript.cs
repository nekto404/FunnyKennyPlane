using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

  
    PlaneControllScript planeControll;

    public float gameTime=0;
	// Use this for initialization
	void Start () {
        planeControll = GameObject.Find("Plane").GetComponent<PlaneControllScript>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
	}

    public void OnClickDown()
    {
        planeControll.Down();
    }

    public void OnClickUp()
    {
        planeControll.Up();
    }
}
