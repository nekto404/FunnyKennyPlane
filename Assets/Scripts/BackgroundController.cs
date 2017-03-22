using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public float speed;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
        
        if (transform.position.x<-17.775f)
        {
            Debug.Log("just");
            transform.Translate(new Vector3(17.775f*2, 0, 0));
        }
    }
}
