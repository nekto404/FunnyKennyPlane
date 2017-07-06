using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public float speed;
    public GameControllerScript gameControllerScript;

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameControllerScript.getEnd() || gameControllerScript.getPause()) return;
	    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

	    if (transform.position.x < -17.775f)
	    {
	        transform.Translate(new Vector3(17.775f * 2, 0, 0));
	    }
	}
}
