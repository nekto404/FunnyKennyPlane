using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

  
    PlaneControllScript planeControll;
	// Use this for initialization
	void Start () {
        planeControll = GameObject.Find("Plane").GetComponent<PlaneControllScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickDown()
    {
        Debug.Log("1");
        planeControll.Down();
    }

    public void OnClickUp()
    {
        Debug.Log("2");
        planeControll.Up();
    }
}
